using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net; 
using System.Web.Script.Serialization;

using BccService.Core.Models.External;
using BccService.Core.Models.Internal;
namespace BccService.Core
{
    public class GoogleContractor : ServiceContractor
    {
        private SystemContractor _sysContractor = null;
        public GoogleContractor(DbConnection connection)
            : base(connection)
        {
            _sysContractor = new SystemContractor(connection);
        }
         
        public UploadResult UploadImage(byte[] imageBytes, string mimeType, string serviceUrl, string authenToken)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                httpWebRequest.ContentType = mimeType;
                httpWebRequest.Method = "POST";
                httpWebRequest.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                httpWebRequest.Headers["Authorization"] = authenToken;

                using (var streamWriter = httpWebRequest.GetRequestStream())
                {
                    streamWriter.Write(imageBytes, 0, imageBytes.Length);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();

                        return new UploadResult
                        {
                            Success = true,
                            Message = result,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // If unauthorize (401) occure report to caller.
                if (ex is WebException)
                {
                    var webEx = ex as WebException;
                    using (WebResponse response = webEx.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            return new UploadResult
                            {
                                Success = false,
                                Message = ex.Message + (ex.InnerException != null ? ">>" + ex.InnerException.Message : ""),
                                Unauthorize = true,
                            };
                        }
                    }
                }

                // all else return exception as it got.
                return new UploadResult
                {
                    Success = false,
                    Message = ex.Message + (ex.InnerException != null ? ">>" + ex.InnerException.Message : "")
                };
            }
        }

        public ShareContentResult MoveContentToShareFolder(string contentId, string shareFolderId, string authenToken)
        {
            try
            {
                var serviceUrl = string.Format("https://www.googleapis.com/drive/v2/files/{0}", contentId);
                List<GoogleDriveParentModel> parents = new List<GoogleDriveParentModel>();
                parents.Add(new GoogleDriveParentModel { id = shareFolderId });

                var body = new
                {
                    parents = parents
                };

                var serializer = new JavaScriptSerializer();
                string parameters = serializer.Serialize(body);

                var res = _sysContractor.DoSendDataToServer("PUT", serviceUrl, parameters, authenToken);
                if (!res.Success) return new ShareContentResult { Success = false, Message = res.Message, DownloadUrl = serviceUrl };

                var resObj = serializer.Deserialize<GoogleDriveMoveFileResponseModel>(res.Message);

                return new ShareContentResult
                {
                    Success = true,
                    DownloadUrl = resObj.webContentLink,
                    PreviewUrl = resObj.thumbnailLink
                };
            }
            catch (Exception ex)
            {
                return new ShareContentResult { Success = false, Message = ex.Message };
            }
        }

        public RefreshTokenResult RefreshAccessToken()
        {
            try
            { 
                var systemConfigDict = _sysContractor.GetSystemInfoDict(new string[] { "DRIVE_TOKEN_SVC", "DRIVE_CLIENT_ID", "DRIVE_CLIENT_SECRET", "DRIVE_REFRESH_TOKEN" });
                var refreshSvc = systemConfigDict["DRIVE_TOKEN_SVC"];
                var refreshToken = systemConfigDict["DRIVE_REFRESH_TOKEN"];
                NameValueCollection outgoingQueryString = System.Web.HttpUtility.ParseQueryString(String.Empty);
                outgoingQueryString.Add("client_id", systemConfigDict["DRIVE_CLIENT_ID"]);
                outgoingQueryString.Add("client_secret", systemConfigDict["DRIVE_CLIENT_SECRET"]);
                outgoingQueryString.Add("refresh_token", systemConfigDict["DRIVE_REFRESH_TOKEN"]);
                outgoingQueryString.Add("grant_type", "refresh_token");
                string postdata = outgoingQueryString.ToString();
                var reqTokenRes = _sysContractor.DoSendDataToServer("POST", refreshSvc, postdata, "", "application/x-www-form-urlencoded");
                _sysContractor.LogStatus("refresh-token", "log", "", postdata, reqTokenRes.Message, reqTokenRes.Success.ToString());
                if (!reqTokenRes.Success)
                {
                    return new RefreshTokenResult { Success = false, Message = "Error on refreshing google drive's token.>>" + reqTokenRes.Message };
                }

                var serializer = new JavaScriptSerializer();
                var refreshTokenRes = serializer.Deserialize<GoogleDriveRefreshTokenResultModel>(reqTokenRes.Message);
                var googleDriveToken = string.Format("{0} {1}", refreshTokenRes.token_type, refreshTokenRes.access_token);
                _sysContractor.LogStatus("refresh-token", "log", "", postdata, "", "New token: " + googleDriveToken);
                // Update access token.
                var tokenCon = _context.SystemInfos.Where(s => s.Name == "DRIVE_ACCESS_TOKEN").FirstOrDefault();
                if (tokenCon != null)
                {
                    tokenCon.Value = googleDriveToken;
                    _context.SubmitChanges();
                }

                return new RefreshTokenResult
                {
                    Success = true,
                    AccessToken = googleDriveToken
                };
            }
            catch(Exception ex)
            {
                return new RefreshTokenResult { Success = false, Message = ex.Message };
            } 
        }
    }
}

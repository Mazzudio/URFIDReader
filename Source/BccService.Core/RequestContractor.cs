using System;
using System.Collections.Generic;

using System.Data.Common; 
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

using BccService.Data;
using BccService.Core.Models.External;
using BccService.Core.Models.Internal;
namespace BccService.Core
{
    public class RequestContractor : ServiceContractor
    {
        private GoogleContractor _driveContractor = null;
        private LineContractor _lineContractor = null;
        private SystemContractor _sysContractor = null;
        private Dictionary<string, string> _configs = null;
        public RequestContractor(DbConnection connection)
            : base(connection)
        {
            _driveContractor = new GoogleContractor(connection);
            _lineContractor = new LineContractor(connection);
            _sysContractor = new SystemContractor(connection);
            _configs = _sysContractor.GetSystemInfoDict(new string[] { "DRIVE_IMG_SCHEME", "DRIVE_UPLOAD_SVC", "DRIVE_ACCESS_TOKEN", "DRIVE_REFRESH_TOKEN", "LINE_ACCESS_TOKEN", "LINE_IMG_SCHEME", "LINE_SVC" });
        } 

        public ServiceResult RequestUploadImage(string lineUserId, string messageId)
        {
            try
            {
                var targetUser = _context.Profiles.Where(p => p.LineUserId == lineUserId).FirstOrDefault();
                if (targetUser == null) return new ServiceResult { Success = false, Message = "User not found." };
                 
                string lineAccessToken = _configs["LINE_ACCESS_TOKEN"];
                string googleDriveToken = _configs["DRIVE_ACCESS_TOKEN"]; 

                // Download image data from LINE's service. 
                var lineDownloadUrl = string.Format(_configs["LINE_IMG_SCHEME"], messageId);
                var client = new WebClient();
                client.Headers.Add("Authorization", lineAccessToken);
                var data = client.DownloadData(lineDownloadUrl);
                if (data.Length == 0)
                {
                    return new ServiceResult { Success = false, Message = "No image data om LINE's service. Url:" + lineDownloadUrl };
                }
                var serializer = new JavaScriptSerializer();
                // Upload image data to Google Drive service. 
                var uploadRes = _driveContractor.UploadImage(data, "image/jpeg", _configs["DRIVE_UPLOAD_SVC"], googleDriveToken);
                if (!uploadRes.Success)
                {
                    if (uploadRes.Unauthorize)
                    {
                        // Refresh token.
                        var refreshRes = _driveContractor.RefreshAccessToken();
                        if (!refreshRes.Success)
                        {
                            return new ServiceResult { Success = false, Message = refreshRes.Message };
                        }
                        googleDriveToken = refreshRes.AccessToken;
                         
                        // Reupload file again. 
                        uploadRes = _driveContractor.UploadImage(data, "image/jpeg", _configs["DRIVE_UPLOAD_SVC"], googleDriveToken);
                        if (!uploadRes.Success)
                        {
                            return new ServiceResult { Success = false, Message = "Error on upload data to google drive.>>" + uploadRes.Message };
                        }
                    }
                    else
                    {
                        return new ServiceResult { Success = false, Message = "Error on upload data to google drive.>>" + uploadRes.Message };
                    } 
                }
                
                var resultObj = serializer.Deserialize<GoogleDriveUploadResultModel>(uploadRes.Message);

                // Move content to share folder.
                var moveRes = _driveContractor.MoveContentToShareFolder(resultObj.id, "1JP8Bem2LvUtV0ByYR_7PBx_Kbu8PxFbU", googleDriveToken);

                if (!moveRes.Success)
                {
                    return new ServiceResult { Success = false, Message = "Error on move file to share folder on google drive.>>" + moveRes.Message +">>" + moveRes.DownloadUrl };
                }
                // Create content data.
                var newContent = new Content
                {
                    EntryDate = DateTime.Now,
                    ProfileId = targetUser.Id,
                    DriveContentId = resultObj.id,
                    DriveDownloadUrl = moveRes.DownloadUrl,
                    DrivePreviewUrl = moveRes.PreviewUrl,
                    MimeType = resultObj.mimeType,
                    LineMessageId = messageId
                };
                _context.Contents.InsertOnSubmit(newContent);
                _context.SubmitChanges();

                // Create content access.
                var access = new ContentAccess
                {
                    EntryDate = DateTime.Now,
                    ContentId = newContent.Id,
                    ProfileId = targetUser.Id,
                };
                _context.ContentAccesses.InsertOnSubmit(access);
                _context.SubmitChanges();

                return new ServiceResult { Success = true, Message = newContent.Id.ToString("00000") };
            }
            catch(Exception ex)
            {
                return new ServiceResult { Success = false, Message =  ex.Message };
            } 
        }

        public ServiceResult ReplyImageContent(int profileId, string contenId, string replyToken)
        {
            long id = 0;
            if(!long.TryParse(contenId, out id))
            {
                return new ServiceResult { Success = false, Message = "Not a content id." };
            }
             
            var content = (from a in _context.ContentAccesses
                           join c in _context.Contents on a.ContentId equals c.Id
                           where !a.Inactive && !c.Inactive
                           && c.Id == id
                           && a.ProfileId == profileId
                           select c).FirstOrDefault();
            if(content == null)
            {
                return new ServiceResult { Success = false, Message = "Content not found." };
            } 
            string imageUrl = content.DriveDownloadUrl; 
            string previewUrl = content.DrivePreviewUrl;

            List<LineSendMessageModel> messages = new List<LineSendMessageModel>();
            messages.Add(new LineSendMessageModel
            {
                type = "image", 
                originalContentUrl = imageUrl,
                previewImageUrl = previewUrl,
            });
            _sysContractor.LogStatus("reply-image", "debug", "", imageUrl, "", "preview:" + previewUrl);
            return _lineContractor.ReplyToUser(replyToken, messages);
        }

        public ServiceResult PushImageContent(int profileId, string contenId, string targetUserName)
        {
            // Check for user.
            var targetUser = (from p in _context.Profiles
                             where p.DefaultName == targetUserName
                             select p).FirstOrDefault();
            if (targetUser == null) return new ServiceResult { Success = false, Message = "User not found." };
            long id = 0;
            if (!long.TryParse(contenId, out id))
            {
                return new ServiceResult { Success = false, Message = "Not a content id." };
            }

            // Only owner can sent to other.
            var content = (from c in _context.Contents 
                           where !c.Inactive
                           && c.Id == id
                           && c.ProfileId == profileId
                           select c).FirstOrDefault();
            if (content == null)
            {
                return new ServiceResult { Success = false, Message = "Content not found or unauthorized." };
            }  
            string imageUrl = content.DriveDownloadUrl; 
            string previewUrl = content.DrivePreviewUrl;
            // Add content accessable.
            var access = new ContentAccess
            {
                EntryDate = DateTime.Now,
                ContentId = content.Id,
                ProfileId = targetUser.Id,
            };
            _context.ContentAccesses.InsertOnSubmit(access);
            _context.SubmitChanges();

            List<LineSendMessageModel> messages = new List<LineSendMessageModel>();
            messages.Add(new LineSendMessageModel
            {
                type = "text",
                text = string.Format("'{0}' send you an image.\r\nTo recovery please type:\r\n?{1}>>me", targetUser.DefaultName, contenId)
            });
            messages.Add(new LineSendMessageModel
            {
                type = "image",
                originalContentUrl = imageUrl,
                previewImageUrl = previewUrl,
            });
            _sysContractor.LogStatus("push-image", "debug", "", imageUrl, "", "preview:" + previewUrl);
            return _lineContractor.PushToUser(targetUser.LineUserId, messages);
        }
    } 
}

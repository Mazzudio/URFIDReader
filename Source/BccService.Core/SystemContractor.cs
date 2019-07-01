using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

using BccService.Data;
using BccService.Core.Models.External;
using BccService.Core.Models.Internal;
namespace BccService.Core
{
    public class SystemContractor : ServiceContractor
    { 
        public SystemContractor(DbConnection connection)
            : base(connection)
        {
            
        }

        public void LogNotify(string destination, List<LineEventItem> events)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                string param = serializer.Serialize(events);

                LogStatus("log-incoming", "log", "", "des:" + destination, "", "events:" + param);
            }
            catch (Exception ex)
            {
                LogStatus("log-incoming", "error", "", destination, "", ex.Message);
            }
        }

        public void LogStatus(string module, string type, string header, string request, string response, string detail, string version = "1.0")
        {
            try
            {
                var log = new ServiceLog
                {
                    EntryDate = DateTime.Now,
                    ModuleName = module,
                    TypeName = type,
                    Headers = header,
                    Request = request,
                    Response = response,
                    Details = detail,
                    ServiceVersion = version
                };
                _context.ServiceLogs.InsertOnSubmit(log);
                _context.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
        } 

        public Dictionary<string, string> GetSystemInfoDict(string[] keys)
        {
            return _context.SystemInfos.Where(s => keys.Contains(s.Name)).ToDictionary(s => s.Name, s => s.Value);
        }

        public ServiceResult DoPostJSON(string serviceUrl, string parameters, string authen)
        {
            return DoSendDataToServer("POST", serviceUrl, parameters, authen);
        }

        public ServiceResult DoSendDataToServer(string method, string serviceUrl, string parameters, string authen, string contentType = "application/json; charset=utf-8", string accept = "application/json; charset=utf-8")
        { 
            try
            { 
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                httpWebRequest.ContentType = contentType;// "application/json; charset=utf-8";
                httpWebRequest.Method = method; 
                httpWebRequest.Accept = accept;

                httpWebRequest.Proxy = null;
                if (!string.IsNullOrEmpty(authen))
                {
                    httpWebRequest.Headers["Authorization"] = authen;
                }

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(parameters);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return new ServiceResult
                        {
                            Success = true,
                            Message = result
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = ex.Message + (ex.InnerException != null ? ">>" + ex.InnerException.Message : "") + ",Params:" + parameters
                };
            }
        }

    }  
}

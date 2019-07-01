using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.Script.Serialization;

using BccService.Core.Models.External;
using BccService.Core.Models.Internal;
namespace BccService.Core
{
    public class LineContractor : ServiceContractor
    {
        private SystemContractor _sysContractor = null; 
        public LineContractor(DbConnection connection)
            : base(connection)
        {
            _sysContractor = new SystemContractor(connection);
        }

        public ServiceResult PushToUser(string lineUserId, List<LineSendMessageModel> messages)
        {
            try
            {
                var systemConfigDict = _sysContractor.GetSystemInfoDict(new string[] { "LINE_SVC", "LINE_ACCESS_TOKEN" });
                string serviceUrl = systemConfigDict["LINE_SVC"] + "/bot/message/push";
                string lineAccessToken = systemConfigDict["LINE_ACCESS_TOKEN"];

                var info = new
                {
                    to = lineUserId,
                    messages = messages
                };
                var serializer = new JavaScriptSerializer();
                string parameters = serializer.Serialize(info);

                var res = _sysContractor.DoPostJSON(serviceUrl, parameters, lineAccessToken);
                return res;
            }
            catch (Exception ex)
            {
                return new ServiceResult { Success = false, Message = ex.Message };
            }
        }

        public ServiceResult ReplyToUser(string replyToken, List<LineSendMessageModel> messages)
        {
            try
            {
                var systemConfigDict = _sysContractor.GetSystemInfoDict(new string[] { "LINE_SVC", "LINE_ACCESS_TOKEN" });
                string serviceUrl = systemConfigDict["LINE_SVC"] + "/bot/message/reply";
                string lineAccessToken = systemConfigDict["LINE_ACCESS_TOKEN"];

                var info = new
                {
                    replyToken = replyToken,
                    messages = messages
                };
                var serializer = new JavaScriptSerializer();
                string parameters = serializer.Serialize(info);

                var res = _sysContractor.DoPostJSON(serviceUrl, parameters, lineAccessToken);
                return res;
            }
            catch (Exception ex)
            {
                return new ServiceResult { Success = false, Message = ex.Message };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using BccService.Core;
using BccService.Core.Models.External;
namespace WebHook
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private RequestContractor _requuestContractor = null;
        private ProfileContractor _profileContractor = null;
        private LineContractor _lineContractor = null;
        private SystemContractor _systemContractor = null;
        public Service()
        {
            string conString = ConfigurationManager.ConnectionStrings["BCCConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            _profileContractor = new ProfileContractor(connection);
            _requuestContractor = new RequestContractor(connection);
            _lineContractor = new LineContractor(connection);
            _systemContractor = new SystemContractor(connection); 
        } 

        public void Notify(string destination, List<LineEventItem> events)
        {
            try
            {
                _systemContractor.LogNotify(destination, events);
                string[] interestEventTypes = new string[] { "follow", "message" };
                foreach(var ev in events)
                {
                    if (!interestEventTypes.Contains(ev.type)) continue;
                    if(ev.source != null && ev.source.type == "user")
                    {
                        var userRes = _profileContractor.AddNewUserIfNotExist(ev.source.userId);
                        if (userRes.Success)
                        {
                            List<LineSendMessageModel> replyMessages = new List<LineSendMessageModel>();
                            if (ev.message != null)
                            { 
                                if (ev.message.type == "image")
                                {
                                    if(ev.message.contentProvider.type == "line")
                                    {
                                        var uploadRes = _requuestContractor.RequestUploadImage(ev.source.userId, ev.message.id);
                                        if (uploadRes.Success)
                                        { 
                                            replyMessages.Add(new LineSendMessageModel
                                            {
                                                type = "text",
                                                text = "Your image' code is '" + uploadRes.Message + "'"
                                            });
                                            replyMessages.Add(new LineSendMessageModel
                                            {
                                                type = "text",
                                                text = string.Format("To send image to other please type:\r\n?{0}>>[user]", uploadRes.Message)
                                            });
                                        }
                                        _systemContractor.LogStatus("upload-lmg", "log", "", ev.message.id, uploadRes.Message, uploadRes.Success.ToString());
                                    }
                                }
                                else if(ev.message.type == "text")
                                {
                                    var cmd = ev.message.text;
                                    if (cmd.StartsWith("?"))
                                    {
                                        _systemContractor.LogStatus("process-command", "log", "", ev.message.id, "command capture.", "");
                                        var toSignIndex = cmd.IndexOf(">>");
                                        if (toSignIndex > 0)
                                        {
                                            var content = cmd.Substring(1, toSignIndex - 1);
                                            var toId = cmd.Substring(toSignIndex + 2).TrimEnd();
                                            if(toId.ToLower() == "me")
                                            {
                                                var replyRes = _requuestContractor.ReplyImageContent(userRes.ProfileId, content, ev.replyToken);
                                                _systemContractor.LogStatus("cmd-reply", "log", "", ev.message.id, replyRes.Message, replyRes.Success.ToString());

                                                if (!replyRes.Success)
                                                {
                                                    replyMessages.Add(new LineSendMessageModel
                                                    {
                                                        type = "text",
                                                        text = replyRes.Message
                                                    });
                                                }  
                                            }
                                            else
                                            {
                                                var pushRes = _requuestContractor.PushImageContent(userRes.ProfileId, content, toId);
                                                _systemContractor.LogStatus("cmd-reply", "log", "", ev.message.id, pushRes.Message, pushRes.Success.ToString());

                                                replyMessages.Add(new LineSendMessageModel
                                                {
                                                    type = "text",
                                                    text = (pushRes.Success) ? "Data send." : pushRes.Message
                                                });
                                            }
                                        } 
                                    }
                                } 
                            }
                            else if(ev.type == "follow")
                            {
                                replyMessages.Add(new LineSendMessageModel
                                {
                                    type = "text",
                                    text = "Welcome to BCC app!!"
                                });
                                replyMessages.Add(new LineSendMessageModel
                                {
                                    type = "text",
                                    text = string.Format("Your ID is '{0}'", userRes.CallName)
                                });
                            }
                            // Send message back.
                            if (replyMessages.Count > 0)
                            {
                                var replyRes = _lineContractor.ReplyToUser(ev.replyToken, replyMessages);
                                _systemContractor.LogStatus("reply-back", "log", "", ev.message.id, replyRes.Message, replyRes.Success.ToString());
                            }
                        }
                    }
                } 
            }
            catch(Exception ex)
            {
                _systemContractor.LogStatus("notify-incoming", "error", "", destination, "", ex.Message);
            }
        }
    } 
}

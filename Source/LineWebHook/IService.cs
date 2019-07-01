using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
 
using BccService.Core.Models.External;
namespace WebHook
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    { 
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "bcc/notify")]
        void Notify(string destination, List<LineEventItem> events);
    } 
}

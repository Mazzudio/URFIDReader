using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.External
{
    public class LineSendMessageModel
    {
        public string type { get; set; }
        public string text { get; set; }
        public string originalContentUrl { get; set; }
        public string previewImageUrl { get; set; }
    }
}

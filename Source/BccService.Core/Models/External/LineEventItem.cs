using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.External
{ 
    public class LineEventItem : TypableModel
    { 
        public string replyToken { get; set; } 
        public long timestamp { get; set; } 
        public LineSourceModel source { get; set; } 
        public LineReceiveMessageEventModel message { get; set; }
    }
}

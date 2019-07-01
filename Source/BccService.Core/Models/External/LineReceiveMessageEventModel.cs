using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.External
{ 
    public class LineReceiveMessageEventModel : TypableModel
    { 
        public string id { get; set; }

        /* For use with text. */ 
        public string text { get; set; }

        /* For use with file. */ 
        public string fileName { get; set; } 
        public long fileSize { get; set; }

        /* For use with media (image, video, audio). */ 
        public LineContentProviderModel contentProvider { get; set; }
    }
}

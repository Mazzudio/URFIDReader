using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.External
{ 
    public class LineContentProviderModel : TypableModel
    { 
        public string originalContentUrl { get; set; } 
        public string previewImageUrl { get; set; }
    } 
}

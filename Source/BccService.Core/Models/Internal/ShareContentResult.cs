using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.Internal
{
    public class ShareContentResult : ServiceResult
    {
        public string DownloadUrl { get; set; } 
        public string PreviewUrl { get; set; }
    }
}

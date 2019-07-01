using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.External
{
    public class GoogleDriveMoveFileResponseModel
    {
        public string webContentLink { get; set; }
        public string thumbnailLink { get; set; }
        public string mimeType { get; set; }
    }
}

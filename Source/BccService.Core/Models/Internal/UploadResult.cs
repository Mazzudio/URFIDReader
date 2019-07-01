using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.Internal
{
    public class UploadResult : ServiceResult
    {
        public bool Unauthorize { get; set; }
    }
}

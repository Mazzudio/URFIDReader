using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.External
{ 
    public class LineSourceModel : TypableModel
    { 
        public string userId { get; set; }
        public string groupId { get; set; }
        public string roomId { get; set; }
    }
}

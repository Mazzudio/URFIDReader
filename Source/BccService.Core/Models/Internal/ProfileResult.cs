using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccService.Core.Models.Internal
{
    public class ProfileResult : ServiceResult
    {
        public int ProfileId { get; set; }

        public string CallName { get; set; }
    }
}

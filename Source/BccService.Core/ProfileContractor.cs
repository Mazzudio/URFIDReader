using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BccService.Core.Models.Internal;
using BccService.Data;
namespace BccService.Core
{
    public class ProfileContractor : ServiceContractor
    {
        public ProfileContractor(DbConnection connection)
            : base(connection)
        { 
        }

        public ProfileResult AddNewUserIfNotExist(string lineUserId)
        {
            try
            {
                var exist = _context.Profiles.Where(p => p.LineUserId == lineUserId).FirstOrDefault();
                if (exist != null)
                {
                    return new ProfileResult { Success = true, ProfileId = exist.Id, CallName = exist.DefaultName };
                }
                var newUser = new Profile
                {
                    EntryDate = DateTime.Now,
                    LineUserId = lineUserId,
                    DefaultName = "",
                };
                _context.Profiles.InsertOnSubmit(newUser);
                _context.SubmitChanges();
                newUser.DefaultName = string.Format("{0:0000}", newUser.Id);
                _context.SubmitChanges();

                return new ProfileResult
                {
                    Success = true,
                    ProfileId = newUser.Id,
                    CallName = newUser.DefaultName
                };
            }
            catch (Exception ex)
            {
                return new ProfileResult { Success = false, Message = ex.Message };
            }
        }
    }
}

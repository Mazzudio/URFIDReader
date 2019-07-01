using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

using BccService.Data;

namespace BccService.Core
{
    public class ServiceContractor
    {
        protected BccDataContext _context = null;
        protected DbConnection _connection = null; 

        public ServiceContractor(DbConnection connection)
        {
            _connection = connection;
            _context = new BccDataContext(connection);
        }

        public void RefreshContext()
        {
            _context = new BccDataContext(_connection);
        }
    }
}

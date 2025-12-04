using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Secret
    {
        protected static string _connectionString = @"Data Source=mssql17.unoeuro.com;
    Initial Catalog=mangoscave_dk_db_eksamensprojekt;User ID=mangoscave_dk;Password=kt6mryFGgep9DhHRAwn5;
    Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
    }
}
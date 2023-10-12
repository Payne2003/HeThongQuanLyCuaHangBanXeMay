using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Db
{
    public abstract class DbConnection
    {
        private readonly string connectionString;

        public DbConnection()
        {
            connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        }

        protected SqlConnection GetConnection()
        {
           return  new SqlConnection(connectionString);
        }
    }
}

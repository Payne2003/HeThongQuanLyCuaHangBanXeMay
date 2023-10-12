using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using QLCHBX.Db;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnection = QLCHBX.Db.DbConnection;

namespace QLCHBX.Model_Khach_Hang
{
    public class DashBoard : DbConnection
    {
        private string ID;
        private string Ten;
        private string Diachi;
        private string Sodienthoai;

        public DashBoard()
        {
        }

       private void GetNumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "";



                }
            }
        }
    }
}

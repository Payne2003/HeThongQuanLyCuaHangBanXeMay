using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QLCHBX
{
    public class ProcessDatabase
    {
        SqlConnection con;
        string constring;

        public ProcessDatabase()
        {
            constring = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        public void KetNoi()
        {
            con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }
        public void DongKetNoi()
        {
            con = new SqlConnection(constring);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                con.Dispose();
            }
        }
        public DataTable DocBang(string sql)
        {
            DataTable dtBang = new DataTable();
            KetNoi();
            SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, con);
            sqldataAdapte.Fill(dtBang);
            DongKetNoi();
            return dtBang;
        }

        public DataTable DocBang(string sql, SqlParameter sqlParameter)
        {
            DataTable dt = new DataTable();
            KetNoi(); // Assuming KetNoi opens the connection
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add(sqlParameter);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            DongKetNoi(); // Assuming DongKetNoi closes the connection
            return dt;
        }
        public void CapNhatDuLieu(string sql)
        {
            KetNoi();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = con;
            sqlcommand.CommandText = sql;
            sqlcommand.ExecuteNonQuery();
            DongKetNoi();
        }
        public SqlDataReader DocDuLieu(string sql)
        {
            KetNoi();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = con;
            sqlCommand.CommandText = sql;
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            return dataReader;
        }
        public bool ExecuteNonQuery(string sql, SqlParameter[] sqlParameters)
        {
            try
            {
                KetNoi();
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                sqlCommand.Parameters.AddRange(sqlParameters);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                // Handle exceptions (e.g., log the error)
                return false;
            }
            finally
            {
                DongKetNoi();
            }
        }

        public object ExecuteScalar(string sql, SqlParameter[] sqlParameters)
        {
            try
            {
                KetNoi();
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                sqlCommand.Parameters.AddRange(sqlParameters);
                object result = sqlCommand.ExecuteScalar();
                return result;
            }
            catch (SqlException)
            {
                // Handle exceptions (e.g., log the error)
                return null;
            }
            finally
            {
                DongKetNoi();
            }
        }


    }
}

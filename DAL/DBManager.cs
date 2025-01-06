
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace DAL
{
    public class DBManager
    {

        DataTable dt;
        static SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ITI_db"].ConnectionString);

        public DBManager()
        {

        }

        // Select  -> DisConnected
        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable ExecuteQuery(string Query ,SqlParameter[] sqlParameters)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(Query, sql);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // DisConnected
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int rowsAffetcted = -1;
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.Parameters.AddRange(parameters);
            try
            {
                sql.Open();
                rowsAffetcted = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                sql.Close();
            }
            return rowsAffetcted;
        }



    }
}

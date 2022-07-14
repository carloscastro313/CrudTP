using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CrudTP.Datos
{
    public abstract class Datos
    {
        protected SqlConnection sqlConnection;

        public Datos()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["CrudTP.Properties.Settings.CrudTPConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(stringConnection);
        }

        protected bool ExecuteCommand(SqlCommand command)
        {
            int rowAffected = -1;

            sqlConnection.Open();

            rowAffected = command.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected > 0;
        }

        protected bool ExecuteCommand(string query)
        {
            return ExecuteCommand(new SqlCommand(query, sqlConnection));
        }

        protected DataTable ExecuteDataReader(SqlCommand command)
        {
            DataTable dt = new DataTable();

            sqlConnection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }

            sqlConnection.Close();

            return dt;
        }

        protected DataTable ExecuteDataReader(string query)
        {
            return ExecuteDataReader(new SqlCommand(query, sqlConnection));
        }

    }
}

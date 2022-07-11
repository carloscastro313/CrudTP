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

        protected DataTable ExecuteDataAdapter(SqlCommand command)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            using (sqlDataAdapter)
            {
                sqlDataAdapter.Fill(dt);
            }

            return dt;
        }

        protected DataTable ExecuteDataAdapter(string query)
        {
            return ExecuteDataAdapter(new SqlCommand(query, sqlConnection));
        }
    }
}

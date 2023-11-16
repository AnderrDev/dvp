using System.Data;
using Microsoft.Data.SqlClient;

namespace Api.Datasource.SqlServerDataSource
{
    public class SqlClientFactory : ISqlClientFactory
    {
        private readonly string _connectionString;

        public SqlClientFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    dataTable.Load(sqlDataReader);
                }
            }
            return dataTable;
        }
    }
}

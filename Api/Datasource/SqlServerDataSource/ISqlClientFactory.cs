using System.Data;

namespace Api.Datasource.SqlServerDataSource
{
    public interface ISqlClientFactory
    {
        DataTable GetDataTable(string query);
    }
}

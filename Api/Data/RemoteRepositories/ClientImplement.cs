using System.Data;
using Api.Datasource.SqlServerDataSource;
using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{
    public class ClientImplement : IClientContract
    {
        private readonly ISqlClientFactory _sqlClientFactory;
        public ClientImplement(ISqlClientFactory sqlClientFactory)
        {
            _sqlClientFactory = sqlClientFactory;
        }
        public Task<ClientModel> Create(ClientModel client)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientModel?> Read(int id)
        {
            string query = "EXEC spGetClienteById @Id = " + id;
            DataTable data = _sqlClientFactory.GetDataTable(query);
            ClientModel client = null;
            foreach (DataRow row in data.Rows)
            {
                client = new ClientModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    RazonSocial = row["RazonSocial"].ToString(),
                    IdTipoCliente = Convert.ToInt32(row["IdTipoCliente"]),
                    RFC = row["RFC"].ToString(),
                    FechaDeCreacion = Convert.ToDateTime(row["FechaDeCreacion"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                    DeletedAt = Convert.ToDateTime(row["DeletedAt"]),
                    TipoCliente = null
                };
            }
            return Task.FromResult(client);
        }

        public Task<IEnumerable<ClientModel>> ReadAll()
        {
            string query = "EXEC spGetAllCliente"; // Ajusta según la sintaxis de tu base de datos
            DataTable data = _sqlClientFactory.GetDataTable(query);
            List<ClientModel> clients = new List<ClientModel>();
            foreach (DataRow row in data.Rows)
            {
                clients.Add(new ClientModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    RazonSocial = row["RazonSocial"].ToString(),
                    IdTipoCliente = Convert.ToInt32(row["IdTipoCliente"]),
                    RFC = row["RFC"].ToString(),
                    FechaDeCreacion = Convert.ToDateTime(row["FechaDeCreacion"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                    DeletedAt = Convert.ToDateTime(row["DeletedAt"]),
                    TipoCliente = null
                });
            }
            return Task.FromResult(clients.AsEnumerable());
        }

        public Task<ClientModel> Update(ClientModel client, int id)
        {
            string query = "EXEC spUpdateCliente @Id = " + id + ", @RazonSocial = '" + client.RazonSocial + "', @IdTipoCliente = " + client.IdTipoCliente + ", @RFC = '" + client.RFC + "'"; // Ajusta según la sintaxis de tu base de datos
            DataTable data = _sqlClientFactory.GetDataTable(query);
            ClientModel clientUpdated = null;
            foreach (DataRow row in data.Rows)
            {
                clientUpdated = new ClientModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    RazonSocial = row["RazonSocial"].ToString(),
                    IdTipoCliente = Convert.ToInt32(row["IdTipoCliente"]),
                    RFC = row["RFC"].ToString(),
                    FechaDeCreacion = Convert.ToDateTime(row["FechaDeCreacion"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                    DeletedAt = Convert.ToDateTime(row["DeletedAt"]),
                    TipoCliente = null
                };
            }
            return Task.FromResult(clientUpdated);
        }
    }
}
using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{

    public class ClientTypeImplementLocal : IClientTypeContract
    {

        private List<ClientTypeModel> _clientTypes = new List<ClientTypeModel>()
        {
            new ClientTypeModel()
            {
                Id = 1,
                TipoCliente = "Cliente",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            },
            new ClientTypeModel()
            {
                Id = 2,
                TipoCliente = "Proveedor",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            },
            new ClientTypeModel()
            {
                Id = 3,
                TipoCliente = "Distribuidor",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            },
            new ClientTypeModel()
            {
                Id = 4,
                TipoCliente = "Mayorista",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            },
            new ClientTypeModel()
            {
                Id = 5,
                TipoCliente = "Minorista",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            }
        };

        public Task<ClientTypeModel> Create(ClientTypeModel client)
        {
            _clientTypes.Add(client);
            return Task.FromResult(client);
        }

        public Task<ClientTypeModel?> Read(int id)
        {

            ClientTypeModel? client = _clientTypes.Find(client => client.Id == id);
            return Task.FromResult(client) ?? throw new Exception("Client not found");

        }

        public Task<IEnumerable<ClientTypeModel>> ReadAll()
        {
            return Task.FromResult(_clientTypes.AsEnumerable());
        }

        public Task<ClientTypeModel> Update(ClientTypeModel client, int id)
        {
            return Task.Run(
                () =>
                {
                    ClientTypeModel? clientToUpdate = _clientTypes.Find(client => client.Id == id);
                    if (clientToUpdate != null)
                    {
                        clientToUpdate.TipoCliente = client.TipoCliente;
                        clientToUpdate.UpdatedAt = DateTime.Now;
                        return clientToUpdate;
                    }
                    throw new Exception("Client not found");
                }
            );
        }

        public Task<bool> Delete(int id)
        {
            return Task.Run(
                () =>
                {
                    ClientTypeModel? clientToDelete = _clientTypes.Find(client => client.Id == id);
                    if (clientToDelete != null)
                    {
                        _clientTypes.Remove(clientToDelete);
                        return true;
                    }
                    return false;
                }
            );
        }
    }
}
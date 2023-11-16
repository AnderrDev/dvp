using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{

    public class ClientTypeImplement : IClientTypeContract
    {
        private List<ClientTypeModel> _clientTypes = new List<ClientTypeModel>()
        {
            new ClientTypeModel()
            {
                Id = 1,
                TipoCliente = "Cliente 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new ClientTypeModel()
            {
                Id = 2,
                TipoCliente = "Cliente 2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new ClientTypeModel()
            {
                Id = 3,
                TipoCliente = "Cliente 3",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new ClientTypeModel()
            {
                Id = 4,
                TipoCliente = "Cliente 4",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
        };


        public async Task<ClientTypeModel> Create(ClientTypeModel client)
        {

            return await Task.Run(() =>
                {
                    _clientTypes.Add(client);
                    return client;
                });

        }

        public async Task<ClientTypeModel?> Read(int id)
        {
            return await Task.Run(() =>
            {
                return _clientTypes.Find(client => client.Id == id);
            });
        }

        public async Task<IEnumerable<ClientTypeModel>> ReadAll()
        {
            return await Task.Run(() =>
            {
                return _clientTypes.AsEnumerable();
            });
        }

        public async Task<ClientTypeModel> Update(ClientTypeModel client, int id)
        {
            return await Task.Run(() =>
            {
                ClientTypeModel? clientToUpdate = _clientTypes.Find(client => client.Id == id);
                if (clientToUpdate != null)
                {
                    clientToUpdate.TipoCliente = client.TipoCliente;
                    clientToUpdate.UpdatedAt = DateTime.Now;
                    return clientToUpdate;
                }
                else
                {
                    throw new Exception("Client not found");
                }
            });
        }

        public async Task<bool> Delete(int id)
        {
            return await Task.Run(() =>
            {
                ClientTypeModel? client = _clientTypes.Find(client => client.Id == id);
                if (client != null)
                {
                    _clientTypes.Remove(client);
                    return true;
                }
                else
                {
                    throw new Exception("Client not found");
                }
            });
        }
    }
}
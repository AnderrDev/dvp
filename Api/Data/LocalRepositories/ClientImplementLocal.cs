using System.Data;
using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{
    public class ClientImplementLocal : IClientContract
    {

        private List<ClientModel> _clients = new List<ClientModel>()
        {
            new ClientModel()
            {
                Id = 1,
                RazonSocial = "Cliente 1",
                IdTipoCliente = 1,
                RFC = "RFC 1",
                FechaDeCreacion = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
                TipoCliente = null
            },
            new ClientModel()
            {
                Id = 2,
                RazonSocial = "Cliente 2",
                IdTipoCliente = 2,
                RFC = "RFC 2",
                FechaDeCreacion = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
                TipoCliente = null
            },
            new ClientModel()
            {
                Id = 3,
                RazonSocial = "Cliente 3",
                IdTipoCliente = 3,
                RFC = "RFC 3",
                FechaDeCreacion = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
                TipoCliente = null
            },
            new ClientModel()
            {
                Id = 4,
                RazonSocial = "Cliente 4",
                IdTipoCliente = 4,
                RFC = "RFC 4",
                FechaDeCreacion = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
                TipoCliente = null
            },
        };

        public Task<ClientModel> Create(ClientModel client)
        {
            _clients.Add(client);
            return Task.FromResult(client);
        }



        public Task<ClientModel> Read(int id)
        {

            return Task.Run(() =>
            {
                ClientModel? client = _clients.Find(client => client.Id == id);
                if (client != null)
                {
                    // Buscar el tipo de cliente en la implementacion de tipo de cliente
                    client.TipoCliente = new ClientTypeImplementLocal().Read(client.IdTipoCliente).Result;
                    return client;
                }
                else
                {
                    throw new Exception("Client not found");
                }
            });
        }

        public Task<IEnumerable<ClientModel>> ReadAll()
        {
            List<ClientModel> clients = _clients;

            // Buscar el tipo de cliente en la implementacion de tipo de cliente para cada cliente
            foreach (ClientModel client in clients)
            {
                client.TipoCliente = new ClientTypeImplementLocal().Read(client.IdTipoCliente).Result;
            }

            return Task.FromResult(clients.AsEnumerable());
        }

        public Task<ClientModel> Update(ClientModel client, int id)
        {
            return Task.Run(() =>
            {
                ClientModel? clientToUpdate = _clients.Find(client => client.Id == id);
                if (clientToUpdate != null)
                {
                    clientToUpdate.RazonSocial = client.RazonSocial;
                    clientToUpdate.IdTipoCliente = client.IdTipoCliente;
                    clientToUpdate.RFC = client.RFC;
                    clientToUpdate.FechaDeCreacion = client.FechaDeCreacion;
                    clientToUpdate.UpdatedAt = DateTime.Now;
                    clientToUpdate.TipoCliente = client.TipoCliente;
                }
                else
                {
                    throw new Exception("Client not found");
                }
                return clientToUpdate;
            });
        }

        public Task<bool> Delete(int id)
        {
            return Task.Run(() =>
            {
                ClientModel? clientToDelete = _clients.Find(client => client.Id == id);
                if (clientToDelete != null)
                {
                    _clients.Remove(clientToDelete);
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
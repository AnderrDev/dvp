using Api.Models;

namespace Api.Repositories.Contract
{
    public interface IClientContract
    {
        Task<ClientModel> Create(ClientModel client);
        Task<ClientModel> Read(int id);
        Task<IEnumerable<ClientModel>> ReadAll();
        Task<ClientModel> Update(ClientModel client, int id);
        Task<bool> Delete(int id);
    }
}
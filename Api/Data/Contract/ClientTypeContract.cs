using Api.Models;

namespace Api.Repositories.Contract
{
    public interface IClientTypeContract
    {
        Task<ClientTypeModel> Create(ClientTypeModel client);
        Task<ClientTypeModel?> Read(int id);
        Task<IEnumerable<ClientTypeModel>> ReadAll();
        Task<ClientTypeModel> Update(ClientTypeModel client, int id);
        Task<bool> Delete(int id);
    }
}
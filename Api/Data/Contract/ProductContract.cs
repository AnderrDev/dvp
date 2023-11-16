

using Api.Models;

namespace Api.Repositories.Contract
{
    public interface IProductContract
    {
        Task<ProductModel> Create(ProductModel product);
        Task<ProductModel> Read(int id);
        Task<IEnumerable<ProductModel>> ReadAll();
        Task<ProductModel> Update(ProductModel product, int id);
        Task<bool> Delete(int id);
    }
}
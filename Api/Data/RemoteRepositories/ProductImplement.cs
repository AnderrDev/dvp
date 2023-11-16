using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{
    public class ProductImplement : IProductContract
    {
        public Task<ProductModel> Create(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> Update(ProductModel product, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

}
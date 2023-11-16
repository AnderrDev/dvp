using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{
    public class InvoiceImplement : IInvoiceContract
    {
        public Task<InvoiceModel> Create(InvoiceModel bill)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceModel> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceModel>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceModel> Update(InvoiceModel bill, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

}
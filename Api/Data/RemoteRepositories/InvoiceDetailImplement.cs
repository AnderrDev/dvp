// create implement for the invoice detail resource

using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{
    public class InvoiceDetailImplement : IInvoiceDetailContract
    {

        public Task<InvoiceDetailModel> Create(InvoiceDetailModel invoiceDetail)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDetailModel> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDetailModel> Update(InvoiceDetailModel invoiceDetail, int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDetailModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceDetailModel>> ReadAll()
        {
            throw new NotImplementedException();
        }

        Task<bool> IInvoiceDetailContract.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}


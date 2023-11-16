using Api.Models;

namespace Api.Repositories.Contract
{
    public interface IInvoiceDetailContract
    {
        Task<InvoiceDetailModel> Create(InvoiceDetailModel bill);
        Task<InvoiceDetailModel> Read(int id);
        Task<IEnumerable<InvoiceDetailModel>> ReadAll();
        Task<InvoiceDetailModel> Update(InvoiceDetailModel bill, int id);
        Task<bool> Delete(int id);
    }

}
using Api.Models;
namespace Api.Repositories.Contract
{
    public interface IInvoiceContract
    {
        Task<InvoiceModel> Create(InvoiceModel bill);
        Task<InvoiceModel> Read(int id);
        Task<IEnumerable<InvoiceModel>> ReadAll();
        Task<InvoiceModel> Update(InvoiceModel bill, int id);
        Task<bool> Delete(int id);
    }
}

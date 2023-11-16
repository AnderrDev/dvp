// create implement for the invoice detail resource

using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{
    public class InvoiceDetailImplementLocal : IInvoiceDetailContract
    {

        private List<InvoiceDetailModel> _invoiceDetails = new List<InvoiceDetailModel>()
        {
            new InvoiceDetailModel()
            {
                Id = 1,
                IdFactura = 1,
                IdProducto = 1,
                CantidadDeProducto = 1,
                PrecioUnitario = 1,
                SubTotal = 1,
                Notas = "Notas 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new InvoiceDetailModel()
            {
                Id = 2,
                IdFactura = 2,
                IdProducto = 2,
                CantidadDeProducto = 2,
                PrecioUnitario = 2,
                SubTotal = 2,
                Notas = "Notas 2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new InvoiceDetailModel()
            {
                Id = 3,
                IdFactura = 3,
                IdProducto = 3,
                CantidadDeProducto = 3,
                PrecioUnitario = 3,
                SubTotal = 3,
                Notas = "Notas 3",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            }
        };


        public async Task<InvoiceDetailModel> Create(InvoiceDetailModel invoiceDetail)
        {
            return await Task.Run(() =>
            {
                _invoiceDetails.Add(invoiceDetail);
                return invoiceDetail;
            });
        }

        public async Task<InvoiceDetailModel> Read(int id)
        {
            return await Task.Run(() =>
            {
                InvoiceDetailModel invoiceDetail = _invoiceDetails.Find(invoiceDetail => invoiceDetail.Id == id);

                // buscar los productos en ProductImplementLocal
                ProductImplementLocal productImplementLocal = new ProductImplementLocal();
                invoiceDetail.Producto = productImplementLocal.Read(invoiceDetail.IdProducto).Result;

                return invoiceDetail;
                
            });
        }

        
        public async Task<IEnumerable<InvoiceDetailModel>> ReadAll()
        {
            return await Task.Run(() =>
            {

                // buscar los productos en ProductImplementLocal
                ProductImplementLocal productImplementLocal = new ProductImplementLocal();

                foreach (var invoiceDetail in _invoiceDetails)
                {
                    invoiceDetail.Producto = productImplementLocal.Read(invoiceDetail.IdProducto).Result;
                }

                return _invoiceDetails;
                
            });
        }

        public async Task<InvoiceDetailModel> Update(InvoiceDetailModel invoiceDetail, int id)
        {
            return await Task.Run(() =>
            {
                var index = _invoiceDetails.FindIndex(invoiceDetail => invoiceDetail.Id == id);
                _invoiceDetails[index] = invoiceDetail;
                return invoiceDetail;
            });
        }

        public async Task<InvoiceDetailModel> Delete(int id)
        {
            return await Task.Run(() =>
            {
                var index = _invoiceDetails.FindIndex(invoiceDetail => invoiceDetail.Id == id);
                var invoiceDetail = _invoiceDetails[index];
                _invoiceDetails.RemoveAt(index);
                return invoiceDetail;
            });
        }


        Task<bool> IInvoiceDetailContract.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}


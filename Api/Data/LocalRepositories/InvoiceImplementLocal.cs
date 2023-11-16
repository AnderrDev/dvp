using Api.Data.Repositories;
using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.LocalRepositories
{
    public class InvoiceImplementLocal : IInvoiceContract
    {
        private List<InvoiceModel> _bills = new List<InvoiceModel>()
        {
            new InvoiceModel()
            {
                Id = 1,
                BroadcastDate = DateTime.Now,
                ClientId = 1,
                NumBill = 1,
                NumTotalProducts = 2,
                SubTotal = 100,
                Tax = 16,
                Total = 116
            },
            new InvoiceModel()
            {
                Id = 2,
                BroadcastDate = DateTime.Now,
                ClientId = 2,
                NumBill = 2,
                NumTotalProducts = 3,
                SubTotal = 200,
                Tax = 32,
                Total = 232
            },
            new InvoiceModel()
            {
                Id = 3,
                BroadcastDate = DateTime.Now,
                ClientId = 3,
                NumBill = 3,
                NumTotalProducts = 4,
                SubTotal = 300,
                Tax = 48,
                Total = 348
            },
            new InvoiceModel()
            {
                Id = 4,
                BroadcastDate = DateTime.Now,
                ClientId = 4,
                NumBill = 4,
                NumTotalProducts = 5,
                SubTotal = 400,
                Tax = 64,
                Total = 464
            },
            new InvoiceModel()
            {
                Id = 5,
                BroadcastDate = DateTime.Now,
                ClientId = 3,
                NumBill = 5,
                NumTotalProducts = 6,
                SubTotal = 500,
                Tax = 80,
                Total = 580
            },
            new InvoiceModel()
            {
                Id = 6,
                BroadcastDate = DateTime.Now,
                ClientId = 2,
                NumBill = 6,
                NumTotalProducts = 7,
                SubTotal = 600,
                Tax = 96,
                Total = 696
            },
            new InvoiceModel()
            {
                Id = 7,
                BroadcastDate = DateTime.Now,
                ClientId = 1,
                NumBill = 7,
                NumTotalProducts = 8,
                SubTotal = 700,
                Tax = 112,
                Total = 812
            }
        };

        public async Task<InvoiceModel> Create(InvoiceModel bill)
        {
            return await Task.Run(() =>
            {
                _bills.Add(bill);
                return bill;
            });
        }

        public Task<bool> Delete(int id)
        {
            return Task.Run(() =>
            {
                InvoiceModel? bill = _bills.FirstOrDefault(b => b.Id == id);
                if (bill != null)
                {
                    _bills.Remove(bill);
                    return true;
                }
                return false;
            });
        }

        public Task<InvoiceModel> Read(int id)
        {
            return Task.Run(() =>
            {
                InvoiceModel? bill = _bills.FirstOrDefault(b => b.Id == id);
                // Buscar el  cliente en la implementacion de cliente para cada cliente
                if (bill != null)
                {
                    bill.Client = new ClientImplementLocal().Read(bill.ClientId).Result;

                    // Buscar todos los detalles y agregarlos a bill.InvoiceDetails
                    bill.InvoiceDetails = new InvoiceDetailImplementLocal().ReadAll().Result.Where(id => id.IdFactura == bill.Id).ToList();
                }
                return bill!;
            });
        }

        public Task<IEnumerable<InvoiceModel>> ReadAll()
        {
            return Task.Run(() =>
            {
                List<InvoiceModel> bills = _bills;
                foreach (InvoiceModel bill in bills)
                {
                    // Buscar el cliente en la implementacion de tipo de cliente para cada cliente
                    bill.Client = new ClientImplementLocal().Read(bill.ClientId).Result;

                    // Buscar todos los detalles y agregarlos a bill.InvoiceDetails
                    bill.InvoiceDetails = new InvoiceDetailImplementLocal().ReadAll().Result.Where(id => id.IdFactura == bill.Id).ToList();
                }
                return _bills.AsEnumerable();
            });
        }

        public Task<InvoiceModel> Update(InvoiceModel bill, int id)
        {
            return Task.Run(() =>
            {
                InvoiceModel? billToUpdate = _bills.FirstOrDefault(b => b.Id == id);
                if (billToUpdate != null)
                {
                    billToUpdate.BroadcastDate = bill.BroadcastDate;
                    billToUpdate.ClientId = bill.ClientId;
                    billToUpdate.NumTotalProducts = bill.NumTotalProducts;
                    billToUpdate.SubTotal = bill.SubTotal;
                    billToUpdate.Tax = bill.Tax;
                    billToUpdate.Total = bill.Total;
                    return billToUpdate;
                }
                return null!;
            });
        }
    }
}
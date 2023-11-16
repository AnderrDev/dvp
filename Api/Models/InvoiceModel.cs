namespace Api.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public DateTime BroadcastDate { get; set; }
        public int ClientId { get; set; }
        public int NumBill { get; set; }
        public int NumTotalProducts { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public ClientModel? Client { get; set; }
        public List<InvoiceDetailModel> InvoiceDetails { get; set; }

        
    }
}
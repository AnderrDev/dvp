// create controller for the invoice detail controller resource

using Api.Models;
using Api.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailContract _invoiceDetailContract;

        public InvoiceDetailController(IInvoiceDetailContract invoiceDetailContract)
        {
            _invoiceDetailContract = invoiceDetailContract;
        }

        [HttpGet(Name = "GetInvoiceDetail")]
        public async Task<ActionResult<IEnumerable<InvoiceDetailModel>>> Get()
        {
            var result = await _invoiceDetailContract.ReadAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetInvoiceDetailById")]
        public async Task<ActionResult<InvoiceDetailModel>> Get(int id)
        {
            var result = await _invoiceDetailContract.Read(id);
            return Ok(result);
        }

        [HttpPost(Name = "PostInvoiceDetail")]
        public async Task<ActionResult<InvoiceDetailModel>> Post(InvoiceDetailModel invoiceDetail)
        {
            var result = await _invoiceDetailContract.Create(invoiceDetail);
            return Ok(result);
        }

        [HttpPut("{id}", Name = "PutInvoiceDetail")]
        public async Task<ActionResult<InvoiceDetailModel>> Put(int id, InvoiceDetailModel invoiceDetail)
        {
            var result = await _invoiceDetailContract.Update(invoiceDetail, id);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteInvoiceDetail")]
        public async Task<ActionResult<InvoiceDetailModel>> Delete(int id)
        {
            var result = await _invoiceDetailContract.Delete(id);
            return Ok(result);
        }
    }
}
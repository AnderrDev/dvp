// create a controller for the Invoice resource:


using Api.Models;
using Api.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceContract _InvoiceContract;

        public InvoiceController(IInvoiceContract InvoiceContract)
        {
            _InvoiceContract = InvoiceContract;
        }

        [HttpGet(Name = "GetInvoice")]
        public async Task<ActionResult<IEnumerable<InvoiceModel>>> Get()
        {
            var result = await _InvoiceContract.ReadAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetInvoiceById")]
        public async Task<ActionResult<InvoiceModel>> Get(int id)
        {
            var result = await _InvoiceContract.Read(id);
            return Ok(result);
        }

        [HttpPost(Name = "PostInvoice")]
        public async Task<ActionResult<InvoiceModel>> Post(InvoiceModel Invoice)
        {
            var result = await _InvoiceContract.Create(Invoice);
            return Ok(result);
        }

        [HttpPut("{id}", Name = "PutInvoice")]
        public async Task<ActionResult<InvoiceModel>> Put(int id, InvoiceModel Invoice)
        {
            var result = await _InvoiceContract.Update(Invoice, id);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteInvoice")]
        public async Task<ActionResult<InvoiceModel>> Delete(int id)
        {
            var result = await _InvoiceContract.Delete(id);
            return Ok(result);
        }
    }
}
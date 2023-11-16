// create controller for the product resource

using Api.Models;
using Api.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductContract _productContract;

        public ProductController(IProductContract productContract)
        {
            _productContract = productContract;
        }

        [HttpGet(Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
        {
            var result = await _productContract.ReadAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductModel>> Get(int id)
        {
            var result = await _productContract.Read(id);
            return Ok(result);
        }

        [HttpPost(Name = "PostProduct")]
        public async Task<ActionResult<ProductModel>> Post(ProductModel product)
        {
            var result = await _productContract.Create(product);
            return Ok(result);
        }

        [HttpPut("{id}", Name = "PutProduct")]
        public async Task<ActionResult<ProductModel>> Put(int id, ProductModel product)
        {
            var result = await _productContract.Update(product, id);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<ActionResult<ProductModel>> Delete(int id)
        {
            var result = await _productContract.Delete(id);
            return Ok(result);
        }
    }
}

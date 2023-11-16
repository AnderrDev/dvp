// create controller for the client 

using Api.Models;
using Api.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientContract _clientContract;

        public ClientController(IClientContract clientContract)
        {
            _clientContract = clientContract;
        }

        [HttpGet(Name = "GetClient")]
        public async Task<ActionResult<IEnumerable<ClientModel>>> Get()
        {
            var result = await _clientContract.ReadAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetClientById")]
        public async Task<ActionResult<ClientModel>> Get(int id)
        {
            var result = await _clientContract.Read(id);
            return Ok(result);
        }

        [HttpPost(Name = "PostClient")]
        public async Task<ActionResult<ClientModel>> Post(ClientModel client)
        {
            var result = await _clientContract.Create(client);
            return Ok(result);
        }

        [HttpPut("{id}", Name = "PutClient")]
        public async Task<ActionResult<ClientModel>> Put(int id, ClientModel client)
        {
            var result = await _clientContract.Update(client, id);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        public async Task<ActionResult<ClientModel>> Delete(int id)
        {
            var result = await _clientContract.Delete(id);
            return Ok(result);
        }
    }
}
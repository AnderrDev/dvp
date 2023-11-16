// create controller for the client type resource 

using Api.Models;
using Api.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ClientTypeController : ControllerBase
    {
        private readonly IClientTypeContract _clientTypeContract;

        public ClientTypeController(IClientTypeContract clientTypeContract)
        {
            _clientTypeContract = clientTypeContract;
        }

        [HttpGet(Name = "GetClientType")]
        public async Task<ActionResult<IEnumerable<ClientTypeModel>>> Get()
        {
            var result = await _clientTypeContract.ReadAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetClientTypeById")]
        public async Task<ActionResult<ClientTypeModel>> Get(int id)
        {
            var result = await _clientTypeContract.Read(id);
            return Ok(result);
        }

        [HttpPost(Name = "PostClientType")]
        public async Task<ActionResult<ClientTypeModel>> Post(ClientTypeModel clientType)
        {
            var result = await _clientTypeContract.Create(clientType);
            return Ok(result);
        }

        [HttpPut("{id}", Name = "PutClientType")]
        public async Task<ActionResult<ClientTypeModel>> Put(int id, ClientTypeModel clientType)
        {
            var result = await _clientTypeContract.Update(clientType, id);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteClientType")]
        public async Task<ActionResult<ClientTypeModel>> Delete(int id)
        {
            var result = await _clientTypeContract.Delete(id);
            return Ok(result);
        }
    }
}
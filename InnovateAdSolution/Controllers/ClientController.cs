using InnovateAd.Entities;
using InnovateAd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovateAd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAllClients()
        {
            return Ok(await _clientService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var Client = await _clientService.GetClient(id);
            if (Client == null)
            {
                return BadRequest("Client not found");
            }
            return Ok(Client);
        }
        [HttpPost("{name}/{lastName}/{docType}/{document}/{email}/{clientNumber}")]
        public async Task<ActionResult<Client>> CreateClient(string name, string lastName, string docType, string document, string email, string clientNumber)
        {
            var newClient = await _clientService.CreateClient(name, lastName, docType, document, email, clientNumber);
            return CreatedAtAction(nameof(GetClient), new { newClient.id }, newClient);
        }
    }
}

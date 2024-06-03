using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/clientController")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepo _clientRepository;

        public ClientController(IClientRepo clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            var clients = await _clientRepository.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _clientRepository.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Client client)
        {
            await _clientRepository.CreateClient(client);
            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Client client)
        {
            var existingClient = await _clientRepository.GetClientById(id);
            if (existingClient == null)
            {
                return NotFound();
            }
            await _clientRepository.UpdateClient(id, client);
            return NoContent();
        }
    }
}

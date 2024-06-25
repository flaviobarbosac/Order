using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Order.Dominio;
using Order.Services;

namespace Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clientService;

        public ClientesController(IClienteService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Cliente cliente)
        {
            var createdClient = await _clientService.CreateCliente(cliente);
            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(ObjectId id)
        {
            var cliente = await _clientService.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clientes = await _clientService.GetAllClientes();
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(ObjectId id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("Client ID mismatch");
            }

            var result = await _clientService.UpdateCliente(cliente);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(ObjectId id)
        {
            var result = await _clientService.DeleteCliente(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
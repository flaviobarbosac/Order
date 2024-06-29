using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Order.Dominio;
using Order.Services.Interfaces;

namespace Order.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class OrdensController : ControllerBase
    {
        private readonly IOrdemService _OrdemService;

        public OrdensController(IOrdemService OrdenService)
        {
            _OrdemService = OrdenService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Ordem ordem)
        {
            var createdOrder = await _OrdemService.CreateOrdem(ordem);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(ObjectId id)
        {
            var order = await _OrdemService.GetOrdemById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdem()
        {
            var Order = await _OrdemService.GetAllOrdem();
            return Ok(Order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrdem(ObjectId id, Ordem ordem)
        {
            if (id != ordem.Id)
            {
                return BadRequest("Order ID mismatch");
            }

            var result = await _OrdemService.UpdateOrdem(ordem);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdem(ObjectId id)
        {
            var result = await _OrdemService.DeleteOrdem(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
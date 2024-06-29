using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Order.Dominio;
using Order.Services;

namespace Order.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ItemOrdensController : ControllerBase
    {
        private readonly IItemOrdemService _ItemOrdemService;

        public ItemOrdensController(IItemOrdemService itemOrdenService)
        {
            _ItemOrdemService = itemOrdenService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemOrder(ItemOrdem itemOrdem)
        {
            var createdItemOrder = await _ItemOrdemService.CreateItemOrdem(itemOrdem);
            return CreatedAtAction(nameof(GetItemOrderById), new { id = createdItemOrder.Id }, createdItemOrder);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemOrderById(ObjectId id)
        {
            var order = await _ItemOrdemService.GetItemOrdemById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public ObjectResult GetAllItemOrdemByOrdem(ObjectId orderId)
        {
            var lstItemOrder = _ItemOrdemService.GetAllItemOrdemByOrdem(orderId);
            return Ok(lstItemOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemOrdem(ObjectId id, ItemOrdem itemOrdem)
        {
            if (id != itemOrdem.Id)
            {
                return BadRequest("Item ordem ID mismatch");
            }

            var result = await _ItemOrdemService.UpdateItemOrdem(itemOrdem);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemOrdem(ObjectId id)
        {
            var result = await _ItemOrdemService.DeleteItemOrdem(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
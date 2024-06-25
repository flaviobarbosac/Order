﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Order.Dominio;
using Order.Services;

namespace Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregaController : ControllerBase
    {
        private readonly IEntregaService _entregaService;

        public EntregaController(IEntregaService entregaService)
        {
            _entregaService = entregaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDelivery(Entrega entrega)
        {
            var createdEntrega = await _entregaService.CreateEntrega(entrega);
            return CreatedAtAction(nameof(GetDeliveryById), new { id = createdEntrega.Id }, createdEntrega);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryById(ObjectId id)
        {
            var entrega = await _entregaService.GetEntregaById(id);
            if (entrega == null)
            {
                return NotFound();
            }
            return Ok(entrega);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeliveries()
        {
            var entrega = await _entregaService.GetAllEntregas();
            return Ok(entrega);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(ObjectId id, Entrega entrega)
        {
            if (id != entrega.Id)
            {
                return BadRequest("Entrega ID mismatch");
            }

            var result = await _entregaService.UpdateEntrega(entrega);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(ObjectId id)
        {
            var result = await _entregaService.DeleteEntrega(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
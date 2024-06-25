using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Order.Dominio;
using Order.Services.Interfaces;

namespace Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto(Produto produto)
        {
            var createdProduto = await _produtoService.CreateProduto(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = createdProduto.Id }, createdProduto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(ObjectId id)
        {
            var produto = await _produtoService.GetProdutoById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var produtos = await _produtoService.GetAllProdutos();
            return Ok(produtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(ObjectId id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest("Produto ID mismatch");
            }

            var result = await _produtoService.UpdateProduto(produto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(ObjectId id)
        {
            var result = await _produtoService.DeleteProduto(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
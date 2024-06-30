using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Services;
using System.Threading.Tasks;

namespace Order.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly ViaCepService _viaCepService;

    public EnderecoController(ViaCepService viaCepService)
    {
        _viaCepService = viaCepService;
    }

    [HttpGet("buscar-por-cep/{cep}")]
    public async Task<IActionResult> BuscarPorCep(string cep)
    {
        var endereco = await _viaCepService.BuscarEnderecoPorCep(cep);
        if (endereco == null)
        {
            return NotFound("Endereço não encontrado.");
        }

        return Ok(endereco);
    }
}
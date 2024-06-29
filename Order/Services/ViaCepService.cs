using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Order.Services;
public class ViaCepService
{
    private readonly HttpClient _httpClient;

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Endereco> BuscarEnderecoPorCep(string cep)
    {
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var endereco = JsonConvert.DeserializeObject<Endereco>(content);

        return endereco;
    }
}

public class Endereco
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string Uf { get; set; }
    public string Unidade { get; set; }
    public string Ibge { get; set; }
    public string Gia { get; set; }
}
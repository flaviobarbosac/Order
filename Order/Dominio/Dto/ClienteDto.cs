using MongoDB.Bson;

namespace Order.Dominio.Dto
{
    public class ClienteDto
    { 
        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required string CEP { get; set; }
        public required string Rua { get; set; }
        public required string Numero { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
    }
}

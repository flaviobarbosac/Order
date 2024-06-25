using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Order.Dominio.Dto
{
    public class ProdutoDto
    {        
        public required string Descricao { get; set; }
        public required string PrecoVenda{ get; set; }        
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Dominio
{

    /*
     Removi os dados do endereço da Ordem para uma classe específica para facilitar a busca pelo CEP.       
     */
    public class Ordem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public required string NumeroOrdem { get; set; }
        public required string Descricao { get; set; }
        public decimal ValorTotalOrdem { get; set; }
        public required Cliente Cliente { get; set; }
    }
}

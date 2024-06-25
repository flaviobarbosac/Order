using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Dominio
{
    public class Ordem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public required string NumeroOrdem { get; set; }
        public required string Descricao { get; set; }
        public decimal ValorTotal { get; set; }
        public required Cliente Cliente { get; set; }
    }
}

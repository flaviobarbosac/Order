using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Dominio
{
    public class Entrega
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]        
        public ObjectId Id { get; set; }
        public required string NumeroOrdem { get; set; }
        public DateTime DataHoraEntrega { get; set; }
        public required User User { get; set; }
    }
}
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
        public required string DataHoraEntrega { get; set; }
        public required User User { get; set; }
        public required Ordem Ordem { get; set; }
    }
}
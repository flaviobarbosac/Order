using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Dominio
{
    public class ItemOrdem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public required Ordem Ordem { get; set; }        
        public required Produto Produto { get; set; }
        public required decimal Quantidade { get; set; }
        public required decimal PrecoVenda { get; set; }
        public decimal ValorTotal { get; set; }        
    }
}

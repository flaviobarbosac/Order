using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Dominio
{
    //Criei os itens da ordem para controlar os itens comprados pelo cliente e mais detalhes como qtd e valores (unitario e total).
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

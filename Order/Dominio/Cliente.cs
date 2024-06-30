using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Order.Services;

namespace Order.Dominio
{
    public class Cliente
    {

        // Criei a classe cliente para termos mais dados sobre o processo e também para ter aonde relacionar o endereço de entrega
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required string CEP { get; set; }
        public required Endereco Endereco { get; set; }
    }
}
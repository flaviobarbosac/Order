﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Dominio
{
    //Criei um cadastro de produto para mantermos a coerencia do sistema
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public required string Descricao { get; set; }
        public required string PrecoVenda{ get; set; }        
    }
}
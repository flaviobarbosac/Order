using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Order.Dominio.Dto
{
    public class UserDto
    {        
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
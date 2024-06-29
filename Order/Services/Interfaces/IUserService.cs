using MongoDB.Bson;
using Order.Dominio;
using Order.Dominio.Dto;

namespace Order.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(UserDto userDto);
        Task<string> Authenticate(LoginDto loginDto);
        Task<User> GetUserById(ObjectId id);
        Task<IEnumerable<User>> GetAllUsers();        
        Task<bool> DeleteUser(ObjectId id);
    }
}

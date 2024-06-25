using MongoDB.Bson;
using Order.Dominio;

namespace Order.Services
{
    public interface IClienteService
    {
        Task<Cliente> CreateCliente(Cliente client);
        Task<Cliente> GetClienteById(ObjectId id);
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<bool> UpdateCliente(Cliente client);
        Task<bool> DeleteCliente(ObjectId id);
    }
}
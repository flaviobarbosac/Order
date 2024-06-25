using MongoDB.Bson;
using Order.Dominio;

namespace Order.Services
{
    public interface IEntregaService
    {
        Task<Entrega> CreateEntrega(Entrega entrega);
        Task<Entrega> GetEntregaById(ObjectId id);
        Task<IEnumerable<Entrega>> GetAllEntregas();
        Task<bool> UpdateEntrega(Entrega entrega);
        Task<bool> DeleteEntrega(ObjectId id);
    }
}
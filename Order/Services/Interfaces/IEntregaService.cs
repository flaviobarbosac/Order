using MongoDB.Bson;
using Order.Dominio;
using Order.Dominio.Dto;

namespace Order.Services
{
    public interface IEntregaService
    {
        Task<Entrega> CreateEntrega(Entrega entrega);
        Task<Entrega> GetEntregaById(ObjectId id);
        Task<IEnumerable<Object>> GetAllEntregas();
        Task<bool> UpdateEntrega(Entrega entrega);
        Task<bool> DeleteEntrega(ObjectId id);
        List<EntregaItemDto> ConverteEntrega(Entrega entrega);
        EntregaDto ConverteParaDto(Entrega entrega);
    }
}
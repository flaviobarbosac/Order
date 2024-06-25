using MongoDB.Bson;
using Order.Dominio;

namespace Order.Services.Interfaces
{
    public interface IOrdemService
    {
        Task<Ordem> CreateOrdem(Ordem order);
        Task<Ordem> GetOrdemById(ObjectId id);
        Task<IEnumerable<Ordem>> GetAllOrdem();
        Task<bool> UpdateOrdem(Ordem order);
        Task<bool> DeleteOrdem(ObjectId id);
    }
}
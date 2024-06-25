using MongoDB.Bson;
using Order.Dominio;

namespace Order.Services
{
    public interface IItemOrdemService
    {
        Task<ItemOrdem> CreateItemOrdem(ItemOrdem itemOrdem);        
        Task<ItemOrdem> GetItemOrdemById(ObjectId id);
        IEnumerable<ItemOrdem> GetAllItemOrdemByOrdem(ObjectId OrdemId);
        Task<bool> UpdateItemOrdem(ItemOrdem itemOrdem);
        Task<bool> DeleteItemOrdem(ObjectId id);
    }
}
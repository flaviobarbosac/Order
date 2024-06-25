using MongoDB.Bson;
using MongoDB.Driver;
using Order.Dominio;

namespace Order.Services
{
    public class ItemOrdemService : IItemOrdemService
    {
        private readonly IMongoCollection<ItemOrdem> _itemOrdem;

        public ItemOrdemService(IMongoClient itemOrdem)
        {
            var database = itemOrdem.GetDatabase("TechsysLogDB");
            _itemOrdem = database.GetCollection<ItemOrdem>("ItemOrdem");            
        }   

        public async Task<ItemOrdem> CreateItemOrdem(ItemOrdem itemOrdem)
        {
            await _itemOrdem.InsertOneAsync(itemOrdem);
            return itemOrdem;
        }

        public async Task<bool> DeleteItemOrdem(ObjectId id)
        {
            var result = await _itemOrdem.DeleteOneAsync(c => c.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public IEnumerable<ItemOrdem> GetAllItemOrdemByOrdem(ObjectId ordemId)
        {
            return _itemOrdem.Find(c => c.Ordem.Id == ordemId).ToList();
        }

        public async Task<ItemOrdem> GetItemOrdemById(ObjectId id)
        {
            return _itemOrdem.Find(c => c.Id == id).FirstOrDefault();
        }

        public async Task<bool> UpdateItemOrdem(ItemOrdem itemOrdem)
        {
            itemOrdem.ValorTotal = itemOrdem.Quantidade * itemOrdem.PrecoVenda;
            var result = await _itemOrdem.ReplaceOneAsync(c => c.Id == itemOrdem.Id, itemOrdem);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}

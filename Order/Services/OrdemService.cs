using MongoDB.Bson;
using MongoDB.Driver;
using Order.Dominio;
using Order.Services.Interfaces;

namespace Order.Services
{
    public class OrdemService : IOrdemService
    {
        private readonly IMongoCollection<Ordem> _Ordem;

        public OrdemService(IMongoClient client)
        {
            var database = client.GetDatabase("TechsysLogDB");
            _Ordem = database.GetCollection<Ordem>("Ordem");
        }

        public async Task<Ordem> CreateOrdem(Ordem ordem)
        {
            await _Ordem.InsertOneAsync(ordem);
            await UpdateOrdemValorTotal(ordem.Id);
            return ordem;
        }

        public async Task<Ordem> GetOrdemById(ObjectId id)
        {
            return await _Ordem.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ordem>> GetAllOrdem()
        {
            return await _Ordem.Find(o => true).ToListAsync();
        }

        public async Task<bool> UpdateOrdem(Ordem ordem)
        {
            var result = await _Ordem.ReplaceOneAsync(o => o.Id == ordem.Id, ordem);
            await UpdateOrdemValorTotal(ordem.Id);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteOrdem(ObjectId id)
        {
            var result = await _Ordem.DeleteOneAsync(o => o.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task UpdateOrdemValorTotal(ObjectId ordemId)
        {
            var ordem = await _Ordem.Find(o => o.Id == ordemId).FirstOrDefaultAsync();
            if (ordem != null)
            {
                var itensOrdem = await _itemOrdem.Find(i => i.Ordem.Id == ordemId).ToListAsync();
                ordem.ValorTotal = itensOrdem.Sum(i => i.ValorTotal);
                await _Ordem.ReplaceOneAsync(o => o.Id == ordemId, ordem);
            }
        }
    }
}
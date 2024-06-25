using MongoDB.Bson;
using MongoDB.Driver;
using Order.Dominio;

namespace Order.Services
{
    public class EntregaService : IEntregaService
    {
        private readonly IMongoCollection<Entrega> _entrega;

        public EntregaService(IMongoClient entrega)
        {
            var database = entrega.GetDatabase("TechsysLogDB");
            _entrega = database.GetCollection<Entrega>("Entrega");
        }

        public async Task<Entrega> CreateEntrega(Entrega client)
        {
            await _entrega.InsertOneAsync(client);
            return client;
        }

        public async Task<Entrega> GetEntregaById(ObjectId id)
        {
            return await _entrega.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entrega>> GetAllEntregas()
        {
            return await _entrega.Find(c => true).ToListAsync();
        }

        public async Task<bool> UpdateEntrega(Entrega client)
        {
            var result = await _entrega.ReplaceOneAsync(c => c.Id == client.Id, client);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteEntrega(ObjectId id)
        {
            var result = await _entrega.DeleteOneAsync(c => c.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
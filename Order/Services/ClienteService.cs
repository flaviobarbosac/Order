using MongoDB.Bson;
using MongoDB.Driver;
using Order.Dominio;

namespace Order.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMongoCollection<Cliente> _clients;

        public ClienteService(IMongoClient client)
        {
            var database = client.GetDatabase("TechsysLogDB");
            _clients = database.GetCollection<Cliente>("Clients");
        }

        public async Task<Cliente> CreateCliente(Cliente client)
        {
            await _clients.InsertOneAsync(client);
            return client;
        }

        public async Task<Cliente> GetClienteById(ObjectId id)
        {
            return await _clients.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clients.Find(c => true).ToListAsync();
        }

        public async Task<bool> UpdateCliente(Cliente client)
        {
            var result = await _clients.ReplaceOneAsync(c => c.Id == client.Id, client);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteCliente(ObjectId id)
        {
            var result = await _clients.DeleteOneAsync(c => c.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
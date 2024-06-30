using MongoDB.Bson;
using MongoDB.Driver;
using Order.Dominio;
using Order.Services.Interfaces;

namespace Order.Services
{
    public class NotificacaoLogService : INotificacaoLogService
    {
        private readonly IMongoCollection<NotificacaoLog> _NotificacaoLogs;

        public NotificacaoLogService(IMongoClient client)
        {
            var database = client.GetDatabase("TechsysLogDB");
            _NotificacaoLogs = database.GetCollection<NotificacaoLog>("NotificacaoLogs");
        }

        public async Task<NotificacaoLog> GetByIdAsync(ObjectId id)
        {
            return await _NotificacaoLogs.Find(log => log.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NotificacaoLog>> GetByUserIdAsync(ObjectId userId)
        {
            return await _NotificacaoLogs.Find(log => log.UserId == userId).ToListAsync();
        }

        public async Task<NotificacaoLog> CreateAsync(NotificacaoLog NotificacaoLog)
        {
            await _NotificacaoLogs.InsertOneAsync(NotificacaoLog);
            return NotificacaoLog;
        }
    }
}
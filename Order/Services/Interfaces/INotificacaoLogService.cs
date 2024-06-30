using MongoDB.Bson;
using Order.Dominio;

namespace Order.Services.Interfaces
{
    public interface INotificacaoLogService
    {
        Task<NotificacaoLog> GetByIdAsync(ObjectId id);
        Task<IEnumerable<NotificacaoLog>> GetByUserIdAsync(ObjectId userId);
        Task<NotificacaoLog> CreateAsync(NotificacaoLog notificationLog);
    }
}
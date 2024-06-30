using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using Order.Dominio;
using Order.Services.Interfaces;

namespace Order.Services
{
    public class NotificationHub : Hub
    {
        private readonly INotificacaoLogService _notificationLogService;

        public NotificationHub(INotificacaoLogService notificationLogService)
        {
            _notificationLogService = notificationLogService;
        }

        public async Task SendNotification(string user, string message)
        {
            await Clients.User(user).SendAsync("ReceiveNotification", message);
        }

        public async Task NotificationViewed(string notificationId)
        {
            var userId = Context.UserIdentifier; // Obtém o ID do usuário autenticado

            var notificationLog = new NotificacaoLog
            {
                UserId = ObjectId.Parse(userId),
                NotificationId = ObjectId.Parse(notificationId),
                ViewedAt = DateTime.UtcNow
            };

            await _notificationLogService.CreateAsync(notificationLog);
        }
    }
}
using MongoDB.Bson;
using System;

namespace Order.Dominio
{
    public class NotificacaoLog
    {
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public ObjectId NotificationId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}
using Municorn.NotificationSender.Core.Models;

namespace Municorn.NotificationSender.Core.Repository
{
    /// <summary>
    /// Сущность уведомления в хранилище
    /// </summary>
    public class NotificationEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Статус отправки
        /// </summary>
        public NotificationStatus Status { get; set; }

        /// <summary>
        /// Объект уведомления
        /// </summary>
        public object Notification { get; set; }
    }
}

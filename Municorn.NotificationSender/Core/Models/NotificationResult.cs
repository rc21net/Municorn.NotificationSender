namespace Municorn.NotificationSender.Core.Models
{
    /// <summary>
    /// Результат отправки уведомления
    /// </summary>
    public class NotificationResult
    {
        /// <summary>
        /// Идентификатор уведомления
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Статус отправки
        /// </summary>
        public NotificationStatus Status { get; set; }
    }
}

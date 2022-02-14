namespace Municorn.NotificationSender.Core.Models
{
    /// <summary>
    /// Статусы отправки
    /// </summary>
    public enum NotificationStatus
    {
        /// <summary>
        /// Не отправлено
        /// </summary>
        Failed = 0,

        /// <summary>
        /// Отправлено
        /// </summary>
        Delivered = 1
    }
}

using Municorn.NotificationSender.Core.Models;

namespace Municorn.NotificationSender.Core.NotificationSender
{
    /// <summary>
    /// Интерфейс сервиса для отправки уведомлений
    /// </summary>
    /// <typeparam name="T">Тип уведомлений</typeparam>
    public interface INotificationSender<T>
    {
        /// <summary>
        /// Отправляет уведомление
        /// </summary>
        /// <param name="notification">Уведомление</param>
        /// <returns>Статус отправки</returns>
        Task<NotificationStatus> Send(T notification);
    }
}

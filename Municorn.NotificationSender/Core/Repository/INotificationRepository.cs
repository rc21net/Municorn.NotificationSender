using Municorn.NotificationSender.Core.Models;

namespace Municorn.NotificationSender.Core.Repository
{
    /// <summary>
    /// Интерфейс репозитория уведомлений
    /// </summary>
    public interface INotificationRepository
    {
        /// <summary>
        /// Добавляет уведомление в хранилище
        /// </summary>
        /// <typeparam name="T">Тип уведомления</typeparam>
        /// <param name="notification">Уведомление</param>
        /// <param name="status">Статус отправки уведомления</param>
        /// <returns>Идентификатор уведомления</returns>
        Task<Guid> Add<T>(T notification, NotificationStatus status);

        /// <summary>
        /// Возвращает уведомление из хранилища по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор уведомления</param>
        /// <returns><see cref="NotificationEntity"/></returns>
        Task<NotificationEntity?> GetById(Guid id);
    }
}

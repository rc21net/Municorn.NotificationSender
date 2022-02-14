using Municorn.NotificationSender.Core.Models;

namespace Municorn.NotificationSender.Core.Repository
{
    /// <summary>
    /// Репозиторий уведомлений с сохранением в память
    /// </summary>
    public class NotificationRepository : INotificationRepository
    {
        /// <summary>
        /// Словарь уведомлений
        /// </summary>
        private readonly Dictionary<Guid, NotificationEntity?> _entities = new();

        /// <summary>
        /// Добавляет уведомления в хранилище в памяти
        /// </summary>
        /// <typeparam name="T">Тип уведомления</typeparam>
        /// <param name="notification">Уведомление</param>
        /// <param name="status">Статус отправки уведомления</param>
        /// <returns>Идентификатор уведомления</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<Guid> Add<T>(T notification, NotificationStatus status)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            var id = Guid.NewGuid();
            var entity = new NotificationEntity
            {
                Id = id,
                Notification = notification,
                Status = status
            };

            _entities.Add(id, entity);

            return Task.FromResult(id);
        }

        /// <summary>
        /// Возвращает уведомление из хранилища по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор уведомления</param>
        /// <returns><see cref="NotificationEntity"/></returns>
        public Task<NotificationEntity?> GetById(Guid id)
        {
            if (_entities.ContainsKey(id))
            {
                return Task.FromResult(_entities[id]);
            }

            return Task.FromResult((NotificationEntity)null);
        }
    }
}

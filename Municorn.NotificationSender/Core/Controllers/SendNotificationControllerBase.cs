using Microsoft.AspNetCore.Mvc;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.NotificationSender;
using Municorn.NotificationSender.Core.Repository;

namespace Municorn.NotificationSender.Core.Controllers
{
    /// <summary>
    /// Базовый контроллер для отправки уведомлений
    /// </summary>
    [ApiController]
    public abstract class SendNotificationControllerBase : ControllerBase
    {
        /// <summary>
        /// Репозиторий уведомлений
        /// </summary>
        private readonly INotificationRepository _notificationRepository;

        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        protected SendNotificationControllerBase(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        /// <summary>
        /// Создает и отправляет уведомление
        /// </summary>
        /// <typeparam name="T">Тип уведомления</typeparam>
        /// <param name="sender">Сервис отправки уведомлений для переданного типа уведомлений</param>
        /// <param name="notification">Уведомление</param>
        /// <returns>Результат: идентификатор и статус отправки</returns>
        protected async Task<NotificationResult> Send<T>(INotificationSender<T> sender, T notification)
        {
            var status = await sender.Send(notification);

            var id = await _notificationRepository.Add(notification, status);

            return new NotificationResult
            {
                Id = id,
                Status = status
            };
        }
    }
}

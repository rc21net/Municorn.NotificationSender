using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Municorn.NotificationSender.Core.Controllers;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.NotificationSender;
using Municorn.NotificationSender.Core.Repository;

namespace Municorn.NotificationSender.Modules.Ios
{
    /// <summary>
    /// Контроллер для отправки уведомлений на IOS-устройство
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IosNotificationController : SendNotificationControllerBase
    {
        /// <summary>
        /// Сервис для отправки уведомлений на IOS-устройства
        /// </summary>
        private readonly INotificationSender<IosNotification> _iosNotificationSender;

        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        public IosNotificationController(INotificationRepository notificationRepository,
            INotificationSender<IosNotification> iosNotificationSender) : base(notificationRepository)
        {
            _iosNotificationSender = iosNotificationSender;
        }

        /// <summary>
        /// Отправляет уведомление на IOS-устройство и сохраняет его
        /// </summary>
        /// <param name="notification">Уведомление для IOS-устройств</param>
        /// <returns>Результат: идентификатор и статус отправки</returns>
        [HttpPost]
        public async Task<ActionResult<NotificationResult>> Send([FromBody][Required] IosNotification notification)
        {
            var result = await Send(_iosNotificationSender, notification);

            return Ok(result);
        }
    }
}

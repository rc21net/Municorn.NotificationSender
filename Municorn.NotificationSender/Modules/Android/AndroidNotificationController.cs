using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Municorn.NotificationSender.Core.Controllers;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.NotificationSender;
using Municorn.NotificationSender.Core.Repository;

namespace Municorn.NotificationSender.Modules.Android
{
    /// <summary>
    /// Контроллер для отправки уведомлений на Android-устройство
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AndroidNotificationController : SendNotificationControllerBase
    {
        /// <summary>
        /// Сервис для отправки уведомлений на Android-устройства
        /// </summary>
        private readonly INotificationSender<AndroidNotification> _androidNotificationSender;

        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        public AndroidNotificationController(INotificationRepository notificationRepository,
            INotificationSender<AndroidNotification> androidNotificationSender) : base(notificationRepository)
        {
            _androidNotificationSender = androidNotificationSender;
        }

        /// <summary>
        /// Отправляет уведомление на Android-устройство и сохраняет его
        /// </summary>
        /// <param name="notification">Уведомление для Android-устройств</param>
        /// <returns>Результат: идентификатор и статус отправки</returns>
        [HttpPost]
        public async Task<ActionResult<NotificationResult>> Send([FromBody][Required] AndroidNotification notification)
        {
            var result = await Send(_androidNotificationSender, notification);

            return Ok(result);
        }
    }
}

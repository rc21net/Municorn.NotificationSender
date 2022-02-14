using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Municorn.NotificationSender.Core.Controllers;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.NotificationSender;
using Municorn.NotificationSender.Core.Repository;

namespace Municorn.NotificationSender.Test
{
    /// <summary>
    /// Тестовый контроллер отправки уведомлений
    /// </summary>
    /// <remarks>Используется для тестирования базового абстрактного контроллера <see cref="SendNotificationControllerBase"/></remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class TestNotificationController : SendNotificationControllerBase
    {
        /// <summary>
        /// <see cref="TestNotificationSender"/>
        /// </summary>
        private readonly INotificationSender<TestNotification> _testNotificationSender;

        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        public TestNotificationController(INotificationRepository notificationRepository,
            INotificationSender<TestNotification> testNotificationSender) : base(notificationRepository)
        {
            _testNotificationSender = testNotificationSender;
        }

        /// <summary>
        /// Отправляет уведомление тестового типа и сохраняет его
        /// </summary>
        /// <param name="notification">Уведомление тестового типа</param>
        /// <returns>Результат: идентификатор и статус отправки</returns>
        [HttpPost]
        public async Task<ActionResult<NotificationResult>> Send([FromBody][Required] TestNotification notification)
        {
            var result = await Send(_testNotificationSender, notification);

            return Ok(result);
        }
    }
}

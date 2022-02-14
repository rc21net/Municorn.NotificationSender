using Microsoft.AspNetCore.Mvc;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.Repository;

namespace Municorn.NotificationSender.Core.Controllers
{
    /// <summary>
    /// API контроллер для получения статуса отправки уведомления
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationStatusController : ControllerBase
    {
        /// <summary>
        /// Репозиторий уведомлений
        /// </summary>
        private readonly INotificationRepository _notificationRepository;

        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        public NotificationStatusController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        /// <summary>
        /// Возвращает статус отправки уведомления по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор уведомления</param>
        /// <returns>Статус отправки</returns>
        [HttpGet(("{id}"))]
        public async Task<ActionResult<NotificationStatus>> GetStatus(Guid id)
        {
            var notification = await _notificationRepository.GetById(id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification.Status);
        }
    }
}

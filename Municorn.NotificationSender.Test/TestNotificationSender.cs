using Microsoft.Extensions.Logging;
using Municorn.NotificationSender.Core.NotificationSender;

namespace Municorn.NotificationSender.Test
{
    /// <summary>
    /// Сервис для отправки уведомлений тестового типа
    /// </summary>
    /// <remarks>Используется для тестирования базового абстрактного сервиса <see cref="NotificationSenderBase{T}"/></remarks>
    public class TestNotificationSender : NotificationSenderBase<TestNotification>
    {
        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        public TestNotificationSender(ILogger<NotificationSenderBase<TestNotification>> logger) : base(logger)
        {
        }

        /// <summary>
        /// User-friendly имя сервиса для отправки уведомлений
        /// </summary>
        protected override string Name => "Test NotificationResult Sender";
    }
}

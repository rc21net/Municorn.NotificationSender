using Municorn.NotificationSender.Core.NotificationSender;

namespace Municorn.NotificationSender.Modules.Ios
{
    /// <summary>
    /// Сервис для отправки уведомлений на IOS-устройства
    /// </summary>
    public class IosNotificationSender : NotificationSenderBase<IosNotification>
    {
        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        public IosNotificationSender(ILogger<NotificationSenderBase<IosNotification>> logger) : base(logger)
        {
        }

        /// <summary>
        /// User-friendly имя сервиса для отправки уведомлений
        /// </summary>
        protected override string Name => "IOS NotificationResult Sender";
    }
}

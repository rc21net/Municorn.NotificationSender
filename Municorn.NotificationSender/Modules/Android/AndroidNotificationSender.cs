using Municorn.NotificationSender.Core.NotificationSender;

namespace Municorn.NotificationSender.Modules.Android
{
    /// <summary>
    /// Сервис для отправки уведомлений на Android-устройства
    /// </summary>
    public class AndroidNotificationSender : NotificationSenderBase<AndroidNotification>
    {
        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        public AndroidNotificationSender(ILogger<NotificationSenderBase<AndroidNotification>> logger) : base(logger)
        {
        }

        /// <summary>
        /// User-friendly имя сервиса для отправки уведомлений
        /// </summary>
        protected override string Name => "Android NotificationResult Sender";
    }
}

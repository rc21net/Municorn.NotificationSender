using Municorn.NotificationSender.Core.NotificationSender;
using Municorn.NotificationSender.Core.Repository;
using Municorn.NotificationSender.Modules.Android;
using Municorn.NotificationSender.Modules.Ios;

namespace Municorn.NotificationSender
{
    /// <summary>
    /// IoC контейнер
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// Регистрирует сервисы для отправки уведомлений определенных типов
        /// </summary>
        public static IServiceCollection AddNotificationSender(this IServiceCollection services)
        {
            services.AddSingleton<INotificationSender<IosNotification>, IosNotificationSender>();
            services.AddSingleton<INotificationSender<AndroidNotification>, AndroidNotificationSender>();

            return services;
        }

        /// <summary>
        /// Регистрирует репозиторий уведомлений
        /// </summary>
        public static IServiceCollection AddNotificationRepository(this IServiceCollection services)
        {
            services.AddSingleton<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}

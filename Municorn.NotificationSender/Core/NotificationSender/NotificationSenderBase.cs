using System.Text.Json;
using Municorn.NotificationSender.Core.Models;

namespace Municorn.NotificationSender.Core.NotificationSender
{
    /// <summary>
    /// Базовый класс сервиса для отправки уведомлений
    /// </summary>
    /// <typeparam name="T">Тип кведомления</typeparam>
    public abstract class NotificationSenderBase<T> : INotificationSender<T>
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private readonly ILogger<NotificationSenderBase<T>> _logger;

        /// <summary>
        /// User-friendly имя сервиса для отправки уведомлений
        /// </summary>
        protected abstract string Name { get; }

        /// <summary>
        /// Счетчик попыток отправки
        /// </summary>
        private int _counter = 0;

        /// <summary>
        /// Конструктор: инъекция зависимостей
        /// </summary>
        protected NotificationSenderBase(ILogger<NotificationSenderBase<T>> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Эмулирует отправку уведомлений
        /// </summary>
        /// <param name="notification">Уведомление</param>
        /// <returns>Статус отправки</returns>
        public async Task<NotificationStatus> Send(T notification)
        {
            var sendingNumber = count();

            await Task.Delay(getSendDuration());

            _logger.LogInformation($"{Name}: {JsonSerializer.Serialize(notification)}");

            return sendingNumber == 5 
                ? NotificationStatus.Failed 
                : NotificationStatus.Delivered;
        }

        /// <summary>
        /// Считает попытки отправки
        /// </summary>
        /// <returns>Номер попытки</returns>
        /// <remarks>Счет ведется от 1 до 5, потом сбрасывается</remarks>
        private int count()
        {
            _counter++;

            if (_counter > 5)
            {
                _counter = 1;
            }

            return _counter;
        }

        /// <summary>
        /// Возвращает рандомное время выполнения отправки
        /// </summary>
        /// <returns>Чисто в диапазоне от 500 до 2000</returns>
        private int getSendDuration()
        {
            var random = new Random();
            return random.Next(500, 2000);
        }
    }
}

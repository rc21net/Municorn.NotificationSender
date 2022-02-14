using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.NotificationSender;

namespace Municorn.NotificationSender.Test
{
    /// <summary>
    /// Тесты сервиса отправки уведомлений
    /// </summary>
    public class NotificationSenderTest
    {
        /// <summary>
        /// Тест метода Send базового абстрактного сервиса <see cref="NotificationSenderBase{T}"/>
        /// </summary>
        [Fact]
        public async void Send()
        {
            // arrange
            var mockLogger = new Mock<ILogger<NotificationSenderBase<TestNotification>>>();

            // act
            var sender = new TestNotificationSender(mockLogger.Object);
            var result = await sender.Send(MockHelper.TestNotification);

            // assert
            Assert.IsType<NotificationStatus>(result);
            Assert.Equal(NotificationStatus.Delivered, result);
        }

        /// <summary>
        /// Тест кейса - каждая пятая отправка должна завершаться неуспешно
        /// </summary>
        [Fact]
        public async void SendEveryFiveFailed()
        {
            // arrange
            var mockLogger = new Mock<ILogger<NotificationSenderBase<TestNotification>>>();

            // act
            var sender = new TestNotificationSender(mockLogger.Object);

            for (var i = 1; i < 12; i++)
            {
                var result = await sender.Send(MockHelper.TestNotification);

                // assert
                Assert.Equal(i % 5 == 0 
                    ? NotificationStatus.Failed 
                    : NotificationStatus.Delivered, 
                    result);
            }
        }
    }
}

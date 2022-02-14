using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Newtonsoft.Json;
using Municorn.NotificationSender.Core.Controllers;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.NotificationSender;
using Municorn.NotificationSender.Core.Repository;

namespace Municorn.NotificationSender.Test
{
    /// <summary>
    /// Тесты для контроллеров
    /// </summary>
    public class NotificationControllerTest
    {
        /// <summary>
        /// Тест метода GetStatus контроллера <see cref="NotificationStatusController"/>.
        /// Уведомление найдено
        /// </summary>
        [Fact]
        public async void GetStatus()
        {
            // arrange
            var mockNotificationRepository = new Mock<INotificationRepository>();

            var id = Guid.NewGuid();
            var expected = NotificationStatus.Delivered;

            var notificationEntity = new NotificationEntity
            {
                Id = id,
                Notification = MockHelper.TestNotification,
                Status = expected
            };

            mockNotificationRepository.Setup(r => r.GetById(id)).Returns(Task.FromResult(notificationEntity)!);

            // act
            var notificationStatusController = new NotificationStatusController(mockNotificationRepository.Object);
            var result = await notificationStatusController.GetStatus(id);

            // assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            var value = Assert.IsType<NotificationStatus>(okResult.Value);
            Assert.Equal(expected, value);
        }

        /// <summary>
        /// Тест метода GetStatus контроллера <see cref="NotificationStatusController"/>.
        /// Уведомление не найдено
        /// </summary>
        [Fact]
        public async void GetStatusNotFound()
        {
            // arrange
            var mockNotificationRepository = new Mock<INotificationRepository>();

            var id = Guid.NewGuid();

            mockNotificationRepository.Setup(r => r.GetById(id)).Returns(Task.FromResult((NotificationEntity)null));

            // act
            var notificationStatusController = new NotificationStatusController(mockNotificationRepository.Object);
            var result = await notificationStatusController.GetStatus(id);

            // assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.NotNull(notFoundResult);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        /// <summary>
        /// Тест метода Send базового абстрактного контроллера <see cref="SendNotificationControllerBase"/>
        /// </summary>
        [Fact]
        public async void SendBase()
        {
            // arrange
            var mockNotificationRepository = new Mock<INotificationRepository>();
            var mockTestNotificationSender = new Mock<INotificationSender<TestNotification>>();

            var testNotification = MockHelper.TestNotification;
            var id = Guid.NewGuid();
            var status = NotificationStatus.Delivered;
            var expected = new NotificationResult
            {
                Id = id,
                Status = status
            };

            mockNotificationRepository.Setup(r => r.Add(testNotification, status)).Returns(Task.FromResult(id));
            mockTestNotificationSender.Setup(s => s.Send(testNotification)).Returns(Task.FromResult(status));

            // act
            var notificationController = new TestNotificationController(mockNotificationRepository.Object,
                mockTestNotificationSender.Object);
            var result = await notificationController.Send(testNotification);

            // assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            var value = Assert.IsType<NotificationResult>(okResult.Value);
            Assert. Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(value));
        }
    }
}
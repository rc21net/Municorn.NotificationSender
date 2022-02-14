using System;
using Newtonsoft.Json;
using Xunit;
using Municorn.NotificationSender.Core.Models;
using Municorn.NotificationSender.Core.Repository;

namespace Municorn.NotificationSender.Test
{
    /// <summary>
    /// Тесты для репозитория уведомлений
    /// </summary>
    public class NotificationRepositoryTest
    {
        /// <summary>
        /// Тест добавления в репозиторий
        /// </summary>
        [Fact]
        public async void Add()
        {
            // arrange
            var notification = MockHelper.TestNotification;
            var status = NotificationStatus.Failed;

            // act
            var repository = new NotificationRepository();
            var result = await repository.Add(notification, status);

            // assert
            Assert.IsType<Guid>(result);
            Assert.NotEqual(result, Guid.Empty);
        }

        /// <summary>
        /// Тест поиска в репозитории.
        /// Уведомление найдено
        /// </summary>
        [Fact]
        public async void GetById()
        {
            // arrange
            var notification = MockHelper.TestNotification;
            var status = NotificationStatus.Failed;

            // act
            var repository = new NotificationRepository();
            var id = await repository.Add(notification, status);

            var result = await repository.GetById(id);

            // assert
            Assert.IsType<NotificationEntity>(result);
            Assert.NotNull(result);
            Assert.Equal(status, result.Status);
            Assert.Equal(id, result.Id);
            Assert.Equal(JsonConvert.SerializeObject(notification), JsonConvert.SerializeObject(result.Notification));
        }

        /// <summary>
        /// Тест поиска в репозитории.
        /// Уведомление не найдено
        /// </summary>
        [Fact]
        public async void GetByIdNotFound()
        {
            // arrange
            var notification = MockHelper.TestNotification;
            var status = NotificationStatus.Failed;
            var notFoundId = Guid.NewGuid();

            // act
            var repository = new NotificationRepository();
            var id = await repository.Add(notification, status);

            var result = await repository.GetById(notFoundId);

            // assert
            Assert.Null(result);
        }
    }
}

namespace Municorn.NotificationSender.Test
{
    /// <summary>
    /// Вспомогательный класс для создания Mock-объектов
    /// </summary>
    public static class MockHelper
    {
        /// <summary>
        /// Возвращает экземпляр уведомления тестового типа <see cref="TestNotification"/>
        /// </summary>
        public static TestNotification TestNotification => new()
        {
            PushToken = "qwerty123456",
            Alert = "Any message",
            IsBackground = true,
            Priority = 1
        };
    }
}

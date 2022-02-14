namespace Municorn.NotificationSender.Test
{
    /// <summary>
    /// Тестовый тип уведомлений
    /// </summary>
    public class TestNotification
    {
        public string PushToken { get; set; }

        public string Alert { get; set; }

        public int Priority { get; set; } = 10;

        public bool IsBackground { get; set; } = true;
    }
}

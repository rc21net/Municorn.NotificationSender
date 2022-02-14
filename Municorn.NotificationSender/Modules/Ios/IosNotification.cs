using System.ComponentModel.DataAnnotations;

namespace Municorn.NotificationSender.Modules.Ios
{
    /// <summary>
    /// Уведомление для IOS-устройств
    /// </summary>
    public class IosNotification
    {
        /// <summary>
        /// Уникальный идентификатор девайса, куда будет отправлено уведомление
        /// </summary>
        [Required]
        [StringLength(50)]
        public string PushToken { get; set; }

        /// <summary>
        /// Само сообщение
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string Alert { get; set; }

        public int Priority { get; set; } = 10;

        public bool IsBackground { get; set; } = true;
    }
}

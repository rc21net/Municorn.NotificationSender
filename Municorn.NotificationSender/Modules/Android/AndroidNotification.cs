using System.ComponentModel.DataAnnotations;

namespace Municorn.NotificationSender.Modules.Android
{
    /// <summary>
    /// Уведомление для Android-устройств
    /// </summary>
    public class AndroidNotification
    {
        /// <summary>
        /// Уникальный идентификатор девайса, куда будет отправлено уведомление
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DeviceToken { get; set; }

        /// <summary>
        /// Само сообщение
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string Message { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(2000)]
        public string Condition { get; set; }
    }
}

using System;

namespace EmotionCareServer.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public bool IsPushNotification { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int PsychologistId { get; set; }

        public string NotificationType { get; set; } 

        public string Link { get; set; }

        public string Title { get; set; }

        public bool IsSeen { get; set; } // Se foi vista
    }
}

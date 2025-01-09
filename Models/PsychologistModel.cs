using System.ComponentModel.DataAnnotations;

namespace EmotionCareServer.Models
{
    public class Psychologist
    {
        public int Id { get; set; }
        public int OrganizationListId { get; set; }
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }
        public string Qualifications { get; set; }
        public string WhatsApp { get; set; }
        public int ScheduleId { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public int SessionDurationMinutes { get; set; }
    }
}

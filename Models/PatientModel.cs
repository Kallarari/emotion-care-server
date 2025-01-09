using System.ComponentModel.DataAnnotations;

namespace EmotionCareServer.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }

        public string? ProfilePicture { get; set; }

        [Required]
        public int PsychologistId { get; set; }

        [Required]
        public int OrganizationListId { get; set; }
    }
}

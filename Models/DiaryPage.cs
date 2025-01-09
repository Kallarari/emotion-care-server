using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmotionCareServer.Models
{
    public class DiaryPage
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 10)]
        public int? SleepSection { get; set; }

        [Range(1, 10)]
        public int? EventsSection { get; set; }

        [Range(1, 10)]
        public int? FeelingsSection { get; set; }

        [Range(1, 10)]
        public int? PredominantThoughtsSection { get; set; }

        [Range(1, 10)]
        public int? DailyHabitsSection { get; set; }

        [Range(1, 10)]
        public int? NotesSection { get; set; }

        [Range(1, 10)]
        public int? DayDescriptionSection { get; set; }

        [ForeignKey("Psychologist")]
        public int PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }
    }
}

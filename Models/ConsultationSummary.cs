using System;

namespace EmotionCareServer.Models
{
    public class ConsultationSummary
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Text { get; set; }

        public int PsychologistId { get; set; }

        public DateTime ConsultationDateTime { get; set; }

        // Relacionamentos
        public Patient Patient { get; set; }  // Relacionamento com o paciente
        public Psychologist Psychologist { get; set; }  // Relacionamento com o psicólogo
    }
}

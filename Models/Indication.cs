namespace EmotionCareServer.Models
{
    public class Indication
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }  // O ID do paciente pode ser nulo

        public string ImageLink { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int PsychologistId { get; set; }

        // Relacionamentos
        public Patient? Patient { get; set; }  // Relacionamento opcional com o paciente
        public Psychologist Psychologist { get; set; }  // Relacionamento com psicólogo
    }
}

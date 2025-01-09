using EmotionCareServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Services
{
    public class ConsultationSummaryService : IConsultationSummaryService
    {
        private readonly AppDbContext _context;

        public ConsultationSummaryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConsultationSummary>> GetAllAsync()
        {
            return await _context.ConsultationSummaries
                .Include(cs => cs.Patient)  // Incluir o paciente
                .Include(cs => cs.Psychologist)  // Incluir o psicólogo
                .ToListAsync();
        }

        public async Task<ConsultationSummary?> GetByIdAsync(int id)
        {
            return await _context.ConsultationSummaries
                .Include(cs => cs.Patient)
                .Include(cs => cs.Psychologist)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task<ConsultationSummary> CreateAsync(ConsultationSummary summary)
        {
            _context.ConsultationSummaries.Add(summary);
            await _context.SaveChangesAsync();
            return summary;
        }

        public async Task<ConsultationSummary?> UpdateAsync(int id, ConsultationSummary summary)
        {
            var existingSummary = await _context.ConsultationSummaries.FindAsync(id);
            if (existingSummary == null) return null;

            existingSummary.PatientId = summary.PatientId;
            existingSummary.Text = summary.Text;
            existingSummary.PsychologistId = summary.PsychologistId;
            existingSummary.ConsultationDateTime = summary.ConsultationDateTime;

            await _context.SaveChangesAsync();
            return existingSummary;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var summary = await _context.ConsultationSummaries.FindAsync(id);
            if (summary == null) return false;

            _context.ConsultationSummaries.Remove(summary);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

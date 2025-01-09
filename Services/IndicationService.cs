using EmotionCareServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Services
{
    public class IndicationService : IIndicationService
    {
        private readonly AppDbContext _context;

        public IndicationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Indication>> GetAllAsync()
        {
            return await _context.Indications
                .Include(i => i.Patient)  // Incluir o paciente (se houver)
                .Include(i => i.Psychologist)  // Incluir o psicólogo
                .ToListAsync();
        }

        public async Task<Indication?> GetByIdAsync(int id)
        {
            return await _context.Indications
                .Include(i => i.Patient)
                .Include(i => i.Psychologist)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Indication> CreateAsync(Indication indication)
        {
            _context.Indications.Add(indication);
            await _context.SaveChangesAsync();
            return indication;
        }

        public async Task<Indication?> UpdateAsync(int id, Indication indication)
        {
            var existingIndication = await _context.Indications.FindAsync(id);
            if (existingIndication == null) return null;

            existingIndication.PatientId = indication.PatientId;
            existingIndication.ImageLink = indication.ImageLink;
            existingIndication.Title = indication.Title;
            existingIndication.Text = indication.Text;
            existingIndication.PsychologistId = indication.PsychologistId;

            await _context.SaveChangesAsync();
            return existingIndication;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var indication = await _context.Indications.FindAsync(id);
            if (indication == null) return false;

            _context.Indications.Remove(indication);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

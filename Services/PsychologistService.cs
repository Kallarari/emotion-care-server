using Microsoft.EntityFrameworkCore;
using EmotionCareServer.Models;

    namespace EmotionCareServer.Services
    {
        public class PsychologistService : IPsychologistService
        {
            private readonly AppDbContext _context;

            public PsychologistService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Psychologist>> GetAllAsync()
            {
                return await _context.Psychologists.ToListAsync();
            }

            public async Task<Psychologist?> GetByIdAsync(int id)
            {
                return await _context.Psychologists.FindAsync(id);
            }

            public async Task<Psychologist> CreateAsync(Psychologist psychologist)
            {
                _context.Psychologists.Add(psychologist);
                await _context.SaveChangesAsync();
                return psychologist;
            }

            public async Task<Psychologist?> UpdateAsync(int id, Psychologist psychologist)
            {
                var existing = await _context.Psychologists.FindAsync(id);
                if (existing == null) return null;

                existing.Name = psychologist.Name;
                existing.Qualifications = psychologist.Qualifications;
                existing.WhatsApp = psychologist.WhatsApp;
                existing.ScheduleId = psychologist.ScheduleId;
                existing.Email = psychologist.Email;
                existing.ProfilePicture = psychologist.ProfilePicture;
                existing.SessionDurationMinutes = psychologist.SessionDurationMinutes;
                existing.Password = psychologist.Password;

            await _context.SaveChangesAsync();
                return existing;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var psychologist = await _context.Psychologists.FindAsync(id);
                if (psychologist == null) return false;

                _context.Psychologists.Remove(psychologist);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }

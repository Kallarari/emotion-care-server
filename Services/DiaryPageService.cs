using EmotionCareServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmotionCareServer.Services
{
    public class DiaryPageService : IDiaryPageService
    {
        private readonly AppDbContext _context;

        public DiaryPageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiaryPage>> GetAllAsync()
        {
            return await _context.DiaryPages.Include(dp => dp.Psychologist).ToListAsync();
        }

        public async Task<DiaryPage> GetByIdAsync(int id)
        {
            return await _context.DiaryPages.Include(dp => dp.Psychologist).FirstOrDefaultAsync(dp => dp.Id == id);
        }

        public async Task<DiaryPage> CreateAsync(DiaryPage diaryPage)
        {
            _context.DiaryPages.Add(diaryPage);
            await _context.SaveChangesAsync();
            return diaryPage;
        }

        public async Task<DiaryPage> UpdateAsync(int id, DiaryPage diaryPage)
        {
            var existingDiaryPage = await _context.DiaryPages.FindAsync(id);
            if (existingDiaryPage == null) return null;

            existingDiaryPage.SleepSection = diaryPage.SleepSection;
            existingDiaryPage.EventsSection = diaryPage.EventsSection;
            existingDiaryPage.FeelingsSection = diaryPage.FeelingsSection;
            existingDiaryPage.PredominantThoughtsSection = diaryPage.PredominantThoughtsSection;
            existingDiaryPage.DailyHabitsSection = diaryPage.DailyHabitsSection;
            existingDiaryPage.NotesSection = diaryPage.NotesSection;
            existingDiaryPage.DayDescriptionSection = diaryPage.DayDescriptionSection;
            existingDiaryPage.PsychologistId = diaryPage.PsychologistId;

            await _context.SaveChangesAsync();
            return existingDiaryPage;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var diaryPage = await _context.DiaryPages.FindAsync(id);
            if (diaryPage == null) return false;

            _context.DiaryPages.Remove(diaryPage);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

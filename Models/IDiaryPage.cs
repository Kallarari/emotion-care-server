using EmotionCareServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Services
{
    public interface IDiaryPageService
    {
        Task<IEnumerable<DiaryPage>> GetAllAsync();
        Task<DiaryPage> GetByIdAsync(int id);
        Task<DiaryPage> CreateAsync(DiaryPage diaryPage);
        Task<DiaryPage> UpdateAsync(int id, DiaryPage diaryPage);
        Task<bool> DeleteAsync(int id);
    }

}

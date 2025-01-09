using EmotionCareServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Services
{
    public interface IConsultationSummaryService
    {
        Task<List<ConsultationSummary>> GetAllAsync();
        Task<ConsultationSummary?> GetByIdAsync(int id);
        Task<ConsultationSummary> CreateAsync(ConsultationSummary summary);
        Task<ConsultationSummary?> UpdateAsync(int id, ConsultationSummary summary);
        Task<bool> DeleteAsync(int id);
    }
}

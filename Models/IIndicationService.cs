using EmotionCareServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Services
{
    public interface IIndicationService
    {
        Task<List<Indication>> GetAllAsync();
        Task<Indication?> GetByIdAsync(int id);
        Task<Indication> CreateAsync(Indication indication);
        Task<Indication?> UpdateAsync(int id, Indication indication);
        Task<bool> DeleteAsync(int id);
    }
}

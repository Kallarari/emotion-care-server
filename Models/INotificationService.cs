using EmotionCareServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Services
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAllAsync();
        Task<Notification?> GetByIdAsync(int id);
        Task<Notification> CreateAsync(Notification notification);
        Task<Notification?> UpdateAsync(int id, Notification notification);
        Task<bool> DeleteAsync(int id);
    }
}

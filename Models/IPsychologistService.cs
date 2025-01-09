
namespace EmotionCareServer.Models
{
    public interface IPsychologistService
    {
        Task<List<Psychologist>> GetAllAsync();
        Task<Psychologist?> GetByIdAsync(int id);
        Task<Psychologist> CreateAsync(Psychologist psychologist);
        Task<Psychologist?> UpdateAsync(int id, Psychologist psychologist);
        Task<bool> DeleteAsync(int id);
    }
}

using EmotionCareServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _context;

        public NotificationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification?> GetByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<Notification> CreateAsync(Notification notification)
        {
            notification.CreatedAt = DateTime.UtcNow; // Garantir a data de criação
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<Notification?> UpdateAsync(int id, Notification notification)
        {
            var existingNotification = await _context.Notifications.FindAsync(id);
            if (existingNotification == null) return null;

            existingNotification.IsPushNotification = notification.IsPushNotification;
            existingNotification.ExpirationDate = notification.ExpirationDate;
            existingNotification.UserId = notification.UserId;
            existingNotification.PsychologistId = notification.PsychologistId;
            existingNotification.NotificationType = notification.NotificationType;
            existingNotification.Link = notification.Link;
            existingNotification.Title = notification.Title;
            existingNotification.IsSeen = notification.IsSeen;

            await _context.SaveChangesAsync();
            return existingNotification;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return false;

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace  Notification;

public class NotificationService
{
    private readonly NotificationDbContext _notificationDbContext;

    public NotificationService(NotificationDbContext notificationDbContext)
    {
        _notificationDbContext = notificationDbContext;
    }

    public async Task<Notification> Create(Notification notification)
    {
        _notificationDbContext.Notification.Add(notification);
        await _notificationDbContext.SaveChangesAsync();
        return notification;
    }

    public async Task<List<Notification>> FindAll()
    {
        return await _notificationDbContext.Notification.ToListAsync();
    }

    public async Task<Notification> FindOne(int ID)
    {
        return await _notificationDbContext.Notification.FindAsync(ID);
    }

    public async Task<Notification> Update(Notification updatedNotification)
    {
        _notificationDbContext.Notification.Update(updatedNotification);
        await _notificationDbContext.SaveChangesAsync();
        return updatedNotification;
    }
}
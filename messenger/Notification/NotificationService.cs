using messenger;
using Microsoft.EntityFrameworkCore;

namespace  Notification;

public class NotificationService
{
    private readonly AppDbContext _appDbContext;

    public NotificationService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Notification> Create(Notification notification)
    {
        _appDbContext.Notification.Add(notification);
        await _appDbContext.SaveChangesAsync();
        return notification;
    }

    public async Task<List<Notification>> FindAll()
    {
        return await _appDbContext.Notification.ToListAsync();
    }

    public async Task<Notification> FindOne(int ID)
    {
        return await _appDbContext.Notification.FindAsync(ID);
    }

    public async Task<Notification> Update(Notification updatedNotification)
    {
        _appDbContext.Notification.Update(updatedNotification);
        await _appDbContext.SaveChangesAsync();
        return updatedNotification;
    }
}
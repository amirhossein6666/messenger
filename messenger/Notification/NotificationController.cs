using messenger.Message;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace messenger.Notification;


[Route("[controller]")]
[ApiController]
public class NotificationController: ControllerBase
{
    private readonly NotificationService _notificationService;

    public NotificationController(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    [HttpPost]
    [SwaggerRequestExample(typeof(Notification), typeof(NotificationExamples))]
    public async Task<Notification> Create(Notification notification)
    {
        return await _notificationService.Create(notification);
    }

    [HttpGet]
    public async Task<List<Notification>> FindAll()
    {
        return await _notificationService.FindAll();
    }

    [HttpGet("ID")]
    public async Task<Notification> FindOne(int ID)
    {
        return await _notificationService.FindOne(ID);
    }

    [HttpPatch]
    public async Task<Notification> Update(Notification updatedNotification)
    {
        return await _notificationService.Update(updatedNotification);
    }
}
using  Channel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  Message;

[Route("[controller]")]
[ApiController]
public class MessageController: ControllerBase
{
    private readonly MessageService _messageService;

    public MessageController(MessageService messageService)
    {
        _messageService = messageService;
    }
    [HttpPost]
    [SwaggerRequestExample(typeof(Message), typeof(MessageExamples))]
    public async Task<Message> Create(Message message)
    {
        return await _messageService.Create(message);
    }

    [HttpGet]
    public async Task<List<Message>> FindAll()
    {
        return await _messageService.FindAll();
    }

    [HttpGet("ID")]
    public async Task<Message> FindOne(int ID)
    {
        return await _messageService.FindOne(ID);
    }

    [HttpPatch]
    public async Task<Message> Update(Message message)
    {
        return await _messageService.Update(message);
    }
}
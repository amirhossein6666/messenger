using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace messenger.MessageReply;
[Route("[controller]")]
public class MessageReplyController: ControllerBase
{
    private readonly MessageReplyService _messageReplyService;

    public MessageReplyController(MessageReplyService messageReplyService)
    {
        _messageReplyService = messageReplyService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(MessageReply), typeof(MessageReplyExamples))]
    public async Task<MessageReply> Create(MessageReply messageReply)
    {
        return await _messageReplyService.Create(messageReply);
    }

    [HttpGet]
    public async Task<List<MessageReply>> FindAll()
    {
        return await _messageReplyService.FindAll();
    }

    [HttpGet("{MessageID}/{replyID}")]
    public async Task<MessageReply> FindOne(int MessageID, int replyID)
    {
        return await _messageReplyService.FindOne(MessageID, replyID);
    }

}
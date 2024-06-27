using ChannelMessage;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  GroupMessage;
[Route("[controller]")]
[ApiController]
public class GroupMessageController: ControllerBase
{
    private readonly GroupMessageService _groupMessageService;

    public GroupMessageController(GroupMessageService groupMessageService)
    {
        _groupMessageService = groupMessageService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(GroupMessage), typeof(GroupMessageExamples))]
    public async Task<GroupMessage> Create(GroupMessage groupMessage)
    {
        return await _groupMessageService.Create(groupMessage);
    }

    [HttpGet]
    public async Task<List<GroupMessage>> FindAll()
    {
        return await _groupMessageService.FindAll();
    }

    [HttpGet("{GroupID}/{MessageID}")]
    public async Task<GroupMessage> FindOne(int GroupID, int MessageID)
    {
        return await _groupMessageService.FindOne(GroupID , MessageID);
    }

}
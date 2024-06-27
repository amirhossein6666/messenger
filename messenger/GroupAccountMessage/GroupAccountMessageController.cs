using ChannelAccountMessage;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  GroupAccountMessage;
[Route("[controller]")]
[ApiController]

public class GroupAccountMessageController: ControllerBase
{
    private readonly GroupAccountMessageService _groupAccountMessageService;

    public GroupAccountMessageController(GroupAccountMessageService groupAccountMessageService)
    {
        _groupAccountMessageService = groupAccountMessageService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(GroupAccountMessage), typeof(GroupAccountMessageExamples))]
    public async Task<GroupAccountMessage> Create(GroupAccountMessage groupAccountMessage)
    {
        return await _groupAccountMessageService.Create(groupAccountMessage);
    }

    [HttpGet]
    public async Task<List<GroupAccountMessage>> FindAll()
    {
        return await _groupAccountMessageService.FindAll();
    }

    [HttpGet("{GroupID}/{AccountID}/{MessageID}")]
    public async Task<GroupAccountMessage> FindOne(int GroupID, int AccountID, int MessageID)
    {
        return await _groupAccountMessageService.FindOne(GroupID, AccountID, MessageID);
    }

    [HttpPatch]
    public async Task<GroupAccountMessage> Update(GroupAccountMessage updatedGroupAccountMessage)
    {
        return await _groupAccountMessageService.Update(updatedGroupAccountMessage);
    }
}
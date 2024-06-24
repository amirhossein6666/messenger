using  AccountGroup;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  ChannelMessage;
[Route("[controller]")]
[ApiController]
public class ChannelMessageController: ControllerBase
{
    private readonly ChannelMessageService _channelMessageService;

    public ChannelMessageController(ChannelMessageService channelMessageService)
    {
        _channelMessageService = channelMessageService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(ChannelMessage), typeof(ChannelMessageExamples))]
    public async Task<ChannelMessage> Create(ChannelMessage channelMessage)
    {
        return await _channelMessageService.Create(channelMessage);
    }

    [HttpGet]
    public async Task<List<ChannelMessage>> FindAll()
    {
        return await _channelMessageService.FindAll();
    }

    [HttpGet("{ChannelID}/{MessageID}")]
    public async Task<ChannelMessage> FindOne(int ChannelID, int MessageID)
    {
        return await _channelMessageService.FindOne(ChannelID, MessageID);
    }

}
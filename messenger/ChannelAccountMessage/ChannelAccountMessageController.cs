using  AccountChannel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  ChannelAccountMessage;
[Route("[controller]")]
[ApiController]
public class ChannelAccountMessageController: ControllerBase
{
    private readonly ChannelAccountMessageService _channelAccountMessageService;

    public ChannelAccountMessageController(ChannelAccountMessageService channelAccountMessageService)
    {
        _channelAccountMessageService = channelAccountMessageService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(ChannelAccountMessage), typeof(ChannelAccountMessageExample))]
    public async Task<ChannelAccountMessage> Create(ChannelAccountMessage channelAccountMessage)
    {
        return await _channelAccountMessageService.Create(channelAccountMessage);
    }

    [HttpGet]
    public async Task<List<ChannelAccountMessage>> FindAll()
    {
        return await _channelAccountMessageService.FindAll();
    }

    [HttpGet("{ChannelID}/{AccountID}/{MessageID}")]
    public async Task<ChannelAccountMessage> FindOne(int ChannelID, int AccountID, int MessageID)
    {
        return await _channelAccountMessageService.FindOne(ChannelID, AccountID, MessageID);
    }

    [HttpPatch]
    public async Task<ChannelAccountMessage> Update(ChannelAccountMessage updatedChannelAccountMesssage)
    {
        return await _channelAccountMessageService.Update(updatedChannelAccountMesssage);
    }
}
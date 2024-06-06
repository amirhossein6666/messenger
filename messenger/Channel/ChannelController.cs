using messenger.Account;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace messenger.Channel;

[Route("[controller]")]
[ApiController]
public class ChannelController : ControllerBase
{
    private readonly ChannelService _channelService;

    public ChannelController(ChannelService channelService)
    {
        _channelService = channelService;
    }
    [HttpPost]
    [SwaggerRequestExample(typeof(Channel), typeof(ChannelExamples))]
    public async Task<Channel> Create(Channel account)
    {
        return await _channelService.Create(account);
    }

    [HttpGet]
    public async Task<List<Channel>> FindAll()
    {
        return await _channelService.FindAll();
    }

    [HttpGet("ID")]
    public async Task<Channel> FindOne(int ID)
    {
        return await _channelService.FindOne(ID);
    }

    [HttpPatch]
    public async Task<Channel> Update(Channel account)
    {
        return await _channelService.Update(account);
    }
}
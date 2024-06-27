using  Account;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  AccountChannel;

[Route("[controller]")]
[ApiController]
public class AccountChannelController: ControllerBase
{
    private readonly AccountChannelService _accountChannelService;

    public AccountChannelController(AccountChannelService accountChannelService)
    {
        _accountChannelService = accountChannelService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(AccountChannel), typeof(AccountChannelExample))]
    public async Task<AccountChannel> Create(AccountChannel accountChannel)
    {
        return await _accountChannelService.Create(accountChannel);
    }

    [HttpGet]
    public async Task<List<AccountChannel>> FindAll()
    {
        return await _accountChannelService.FindAll();
    }

    [HttpGet("{AccountID}/{ChannelID}")]
    public async Task<AccountChannel> FindOne(int AccountID, int ChannelID)
    {
        return await _accountChannelService.FindOne(AccountID, ChannelID);
    }

    [HttpPatch]
    public async Task<AccountChannel> Update(AccountChannel updatedAccountChannel)
    {
        return await _accountChannelService.Update(updatedAccountChannel);
    }
}
using Account;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  AccountGroup;
[Route("[controller]")]
[ApiController]
public class AccountGroupController : ControllerBase
{
    private readonly AccountGroupService _accountGroupService;

    public AccountGroupController(AccountGroupService accountGroupService)
    {
        _accountGroupService = accountGroupService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(AccountGroup), typeof(AccountGroupExamples))]
    public async Task<AccountGroup> Create(AccountGroup accountGroup)
    {
        return await _accountGroupService.Create(accountGroup);
    }

    [HttpGet]
    public async Task<List<AccountGroup>> FindAll()
    {
        return await _accountGroupService.FindAll();
    }

    [HttpGet("{AccountID}/{GroupID}")]
    public async Task<AccountGroup> FindOne(int AccountID, int GroupID)
    {
        return await _accountGroupService.FindOne(AccountID, GroupID);
    }

    [HttpPatch]
    public async Task<AccountGroup> Update(AccountGroup updatedAccountGroup)
    {
        return await _accountGroupService.Update(updatedAccountGroup);
    }
}
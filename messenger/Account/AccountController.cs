using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  Account;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(Account), typeof(AccountExamples))]
    public async Task<Account> Create(Account account)
    {
        return await _accountService.Create(account);
    }

    [HttpGet]
    public async Task<List<Account>> FindAll()
    {
        return await _accountService.FindAll();
    }

    [HttpGet("ID")]
    public async Task<Account> FindOne(int ID)
    {
        return await _accountService.FindOne(ID);
    }

    [HttpPatch]
    public async Task<Account> Update(Account updatedAccount)
    {
        return await _accountService.Update(updatedAccount);
    }
}
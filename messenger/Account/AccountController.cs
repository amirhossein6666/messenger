using Microsoft.AspNetCore.Mvc;

namespace messenger.Account;

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
    public async Task<Account> Update(Account account)
    {
        return await _accountService.Update(account);
    }
}
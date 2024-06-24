using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  AccountPV;
[Route("[controller]")]
[ApiController]
public class AccountPVController: ControllerBase
{
    private readonly AccountPVService _accountPVService;

    public AccountPVController(AccountPVService accountPVService)
    {
        _accountPVService = accountPVService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(AccountPV), typeof(AccountPVExamples))]
    public async Task<AccountPV> Create(AccountPV accountPV)
    {
        return await _accountPVService.Create(accountPV);
    }

    [HttpGet]
    public async Task<List<AccountPV>> FindAll()
    {
        return await _accountPVService.FindAll();
    }

    [HttpGet("{AccountID}/{PVID}")]
    public async Task<AccountPV> FindOne(int AccountID, int PVID)
    {
        return await _accountPVService.FindOne(AccountID, PVID);
    }

    [HttpPatch]
    public async Task<AccountPV> Update(AccountPV updatedAccountPV)
    {
        return await _accountPVService.Update(updatedAccountPV);
    }
}
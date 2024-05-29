using Microsoft.AspNetCore.Mvc;

namespace messenger.AccountContact;

[Route("[controller]")]
[ApiController]
public class AccountContactController : ControllerBase
{
    private readonly AccountContactService _accountContactService;

    public AccountContactController(AccountContactService accountContactService)
    {
        _accountContactService = accountContactService;
    }

    [HttpPost]
    public async Task<AccountContact> Create(AccountContact accountContact)
    {
        return await _accountContactService.Create(accountContact);
    }

    [HttpGet]
    public async Task<List<AccountContact>> FindAll()
    {
        return await _accountContactService.FindAll();
    }

    [HttpGet("{AccountID}/{ContactID}")]
    public async Task<AccountContact> FindOne(int AccountID, int ContactID)
    {
        return await _accountContactService.FindOne(AccountID, ContactID);
    }

    [HttpPatch]
    public async Task<AccountContact> Update(AccountContact updatedAccountContact)
    {
        return await _accountContactService.Update(updatedAccountContact);
    }

}
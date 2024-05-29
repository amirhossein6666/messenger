using Microsoft.EntityFrameworkCore;

namespace messenger.AccountContact;

public class AccountContactService
{
    private readonly AccountContactDbContext _accountContactDbContext;

    public AccountContactService(AccountContactDbContext accountContactDbContext)
    {
        _accountContactDbContext = accountContactDbContext;
    }

    public async Task<AccountContact> Create(AccountContact accountContact)
    {
        _accountContactDbContext.AccountContact.Add(accountContact);
        await _accountContactDbContext.SaveChangesAsync();
        return accountContact;
    }

    public async Task<List<AccountContact>> FindAll()
    {
        return await _accountContactDbContext.AccountContact.ToListAsync();
    }

    public async Task<AccountContact> FindOne(int AccountID, int ContactID)
    {
        return await _accountContactDbContext.AccountContact.FindAsync(AccountID, ContactID);
    }

    public async Task<AccountContact> Update(AccountContact updatedAccountContact)
    {
        _accountContactDbContext.AccountContact.Update(updatedAccountContact);
        await _accountContactDbContext.SaveChangesAsync();
        return updatedAccountContact;
    }
}
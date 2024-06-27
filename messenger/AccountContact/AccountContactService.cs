using messenger;
using Microsoft.EntityFrameworkCore;

namespace  AccountContact;

public class AccountContactService
{
    private readonly AppDbContext _appDbContext;

    public AccountContactService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AccountContact> Create(AccountContact accountContact)
    {
        _appDbContext.AccountContacts.Add(accountContact);
        await _appDbContext.SaveChangesAsync();
        return accountContact;
    }

    public async Task<List<AccountContact>> FindAll()
    {
        return await _appDbContext.AccountContacts.ToListAsync();
    }

    public async Task<AccountContact> FindOne(int AccountID, int ContactID)
    {
        return await _appDbContext.AccountContacts.FindAsync(AccountID, ContactID);
    }

    public async Task<AccountContact> Update(AccountContact updatedAccountContact)
    {
        _appDbContext.AccountContacts.Update(updatedAccountContact);
        await _appDbContext.SaveChangesAsync();
        return updatedAccountContact;
    }
}
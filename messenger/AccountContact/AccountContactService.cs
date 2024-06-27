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
        _appDbContext.AccountContact.Add(accountContact);
        await _appDbContext.SaveChangesAsync();
        return accountContact;
    }

    public async Task<List<AccountContact>> FindAll()
    {
        return await _appDbContext.AccountContact.ToListAsync();
    }

    public async Task<AccountContact> FindOne(int AccountID, int ContactID)
    {
        return await _appDbContext.AccountContact.FindAsync(AccountID, ContactID);
    }

    public async Task<AccountContact> Update(AccountContact updatedAccountContact)
    {
        _appDbContext.AccountContact.Update(updatedAccountContact);
        await _appDbContext.SaveChangesAsync();
        return updatedAccountContact;
    }
}
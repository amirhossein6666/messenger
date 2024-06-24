
using Microsoft.EntityFrameworkCore;

namespace  AccountPV;

public class AccountPVService
{
    private readonly AccountPVDbContext _accountPvDbContext;

    public AccountPVService(AccountPVDbContext accountPVDbContext)
    {
        _accountPvDbContext = accountPVDbContext;
    }

    public async Task<AccountPV> Create(AccountPV accountPV)
    {
        _accountPvDbContext.AccountPV.Add(accountPV);
        await _accountPvDbContext.SaveChangesAsync();
        return accountPV;
    }

    public async Task<List<AccountPV>> FindAll()
    {
        return await _accountPvDbContext.AccountPV.ToListAsync();
    }

    public async Task<AccountPV> FindOne(int AccountID, int PVID)
    {
        return await _accountPvDbContext.AccountPV.FindAsync(AccountID, PVID);
    }

    public async Task<AccountPV> Update(AccountPV updatedaccountPV)
    {
        _accountPvDbContext.AccountPV.Update(updatedaccountPV);
        await _accountPvDbContext.SaveChangesAsync();
        return updatedaccountPV;
    }
}
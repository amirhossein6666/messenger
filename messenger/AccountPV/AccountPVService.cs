
using messenger;
using Microsoft.EntityFrameworkCore;

namespace  AccountPV;

public class AccountPVService
{
    private readonly AppDbContext _appDbContext;

    public AccountPVService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AccountPV> Create(AccountPV accountPV)
    {
        _appDbContext.AccountPVs.Add(accountPV);
        await _appDbContext.SaveChangesAsync();
        return accountPV;
    }

    public async Task<List<AccountPV>> FindAll()
    {
        return await _appDbContext.AccountPVs.ToListAsync();
    }

    public async Task<AccountPV> FindOne(int AccountID, int PVID)
    {
        return await _appDbContext.AccountPVs.FindAsync(AccountID, PVID);
    }

    public async Task<AccountPV> Update(AccountPV updatedaccountPV)
    {
        _appDbContext.AccountPVs.Update(updatedaccountPV);
        await _appDbContext.SaveChangesAsync();
        return updatedaccountPV;
    }
}
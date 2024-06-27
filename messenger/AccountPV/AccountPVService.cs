
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
        _appDbContext.AccountPV.Add(accountPV);
        await _appDbContext.SaveChangesAsync();
        return accountPV;
    }

    public async Task<List<AccountPV>> FindAll()
    {
        return await _appDbContext.AccountPV.ToListAsync();
    }

    public async Task<AccountPV> FindOne(int AccountID, int PVID)
    {
        return await _appDbContext.AccountPV.FindAsync(AccountID, PVID);
    }

    public async Task<AccountPV> Update(AccountPV updatedaccountPV)
    {
        _appDbContext.AccountPV.Update(updatedaccountPV);
        await _appDbContext.SaveChangesAsync();
        return updatedaccountPV;
    }
}
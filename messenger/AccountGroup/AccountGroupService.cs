using messenger;
using Microsoft.EntityFrameworkCore;

namespace  AccountGroup;

public class AccountGroupService
{
    private readonly AppDbContext _appDbContext;

    public AccountGroupService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AccountGroup> Create(AccountGroup accountGroup)
    {
        _appDbContext.AccountGroup.Add(accountGroup);
        await _appDbContext.SaveChangesAsync();
        return accountGroup;
    }

    public async Task<List<AccountGroup>> FindAll()
    {
        return await _appDbContext.AccountGroup.ToListAsync();
    }

    public async Task<AccountGroup> FindOne(int AccountID, int GroupID)
    {
        return await _appDbContext.AccountGroup.FindAsync(AccountID, GroupID);
    }

    public async Task<AccountGroup> Update(AccountGroup updatedAccountGroup)
    {
        _appDbContext.AccountGroup.Update(updatedAccountGroup);
        await _appDbContext.SaveChangesAsync();
        return updatedAccountGroup;
    }
}
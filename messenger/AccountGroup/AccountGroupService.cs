using Microsoft.EntityFrameworkCore;

namespace messenger.AccountGroup;

public class AccountGroupService
{
    private readonly AccountGroupDbContext _accountGroupDbContext;

    public AccountGroupService(AccountGroupDbContext accountGroupDbContext)
    {
        _accountGroupDbContext = accountGroupDbContext;
    }

    public async Task<AccountGroup> Create(AccountGroup accountGroup)
    {
        _accountGroupDbContext.AccountGroup.Add(accountGroup);
        await _accountGroupDbContext.SaveChangesAsync();
        return accountGroup;
    }

    public async Task<List<AccountGroup>> FindAll()
    {
        return await _accountGroupDbContext.AccountGroup.ToListAsync();
    }

    public async Task<AccountGroup> FindOne(int AccountID, int GroupID)
    {
        return await _accountGroupDbContext.AccountGroup.FindAsync(AccountID, GroupID);
    }

    public async Task<AccountGroup> Update(AccountGroup updatedAccountGroup)
    {
        _accountGroupDbContext.AccountGroup.Update(updatedAccountGroup);
        await _accountGroupDbContext.SaveChangesAsync();
        return updatedAccountGroup;
    }
}
using Microsoft.EntityFrameworkCore;

namespace  AccountChannel;

public class AccountChannelService
{
    private readonly AccountChannelDbContext _accountChannelDbContext;

    public AccountChannelService(AccountChannelDbContext accountChannelDbContext)
    {
        _accountChannelDbContext = accountChannelDbContext;
    }

    public async Task<AccountChannel> Create(AccountChannel accountChannel)
    {
        _accountChannelDbContext.AccountChannel.Add(accountChannel);
        await _accountChannelDbContext.SaveChangesAsync();
        return accountChannel;
    }

    public async Task<List<AccountChannel>> FindAll()
    {
        return await _accountChannelDbContext.AccountChannel.ToListAsync();
    }

    public async Task<AccountChannel> FindOne(int AccountID, int ChannelID)
    {
        return await _accountChannelDbContext.AccountChannel.FindAsync(AccountID, ChannelID);
    }

    public async Task<AccountChannel> Update(AccountChannel updatedAccountChannel)
    {
        _accountChannelDbContext.AccountChannel.Update(updatedAccountChannel);
        await _accountChannelDbContext.SaveChangesAsync();
        return updatedAccountChannel;
    }
}
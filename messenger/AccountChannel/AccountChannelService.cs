using messenger;
using Microsoft.EntityFrameworkCore;

namespace  AccountChannel;

public class AccountChannelService
{
    private readonly AppDbContext _appDbContext;

    public AccountChannelService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AccountChannel> Create(AccountChannel accountChannel)
    {
        _appDbContext.AccountChannels.Add(accountChannel);
        await _appDbContext.SaveChangesAsync();
        return accountChannel;
    }

    public async Task<List<AccountChannel>> FindAll()
    {
        return await _appDbContext.AccountChannels.ToListAsync();
    }

    public async Task<AccountChannel> FindOne(int AccountID, int ChannelID)
    {
        return await _appDbContext.AccountChannels.FindAsync(AccountID, ChannelID);
    }

    public async Task<AccountChannel> Update(AccountChannel updatedAccountChannel)
    {
        _appDbContext.AccountChannels.Update(updatedAccountChannel);
        await _appDbContext.SaveChangesAsync();
        return updatedAccountChannel;
    }
}
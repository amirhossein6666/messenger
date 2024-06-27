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
        _appDbContext.AccountChannel.Add(accountChannel);
        await _appDbContext.SaveChangesAsync();
        return accountChannel;
    }

    public async Task<List<AccountChannel>> FindAll()
    {
        return await _appDbContext.AccountChannel.ToListAsync();
    }

    public async Task<AccountChannel> FindOne(int AccountID, int ChannelID)
    {
        return await _appDbContext.AccountChannel.FindAsync(AccountID, ChannelID);
    }

    public async Task<AccountChannel> Update(AccountChannel updatedAccountChannel)
    {
        _appDbContext.AccountChannel.Update(updatedAccountChannel);
        await _appDbContext.SaveChangesAsync();
        return updatedAccountChannel;
    }
}
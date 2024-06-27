using messenger;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace  ChannelAccountMessage;

public class ChannelAccountMessageService
{
    private readonly AppDbContext _appDbContext;

    public ChannelAccountMessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ChannelAccountMessage> Create(ChannelAccountMessage channelAccountMessage)
    {
        _appDbContext.ChannelAccountMessage.Add(channelAccountMessage);
        await _appDbContext.SaveChangesAsync();
        return channelAccountMessage;
    }

    public async Task<List<ChannelAccountMessage>> FindAll()
    {
        return await _appDbContext.ChannelAccountMessage.ToListAsync();
    }

    public async Task<ChannelAccountMessage> FindOne(int ChannelID, int AccountID, int MessageID)
    {
        return await _appDbContext.ChannelAccountMessage.FindAsync(ChannelID, AccountID, MessageID);
    }

    public async Task<ChannelAccountMessage> Update(ChannelAccountMessage updatedChannelAccountMessage)
    {
        _appDbContext.ChannelAccountMessage.Update(updatedChannelAccountMessage);
        await _appDbContext.SaveChangesAsync();
        return updatedChannelAccountMessage;
    }
}
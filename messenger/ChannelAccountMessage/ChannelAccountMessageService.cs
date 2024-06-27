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
        _appDbContext.ChannelAccountMessages.Add(channelAccountMessage);
        await _appDbContext.SaveChangesAsync();
        return channelAccountMessage;
    }

    public async Task<List<ChannelAccountMessage>> FindAll()
    {
        return await _appDbContext.ChannelAccountMessages.ToListAsync();
    }

    public async Task<ChannelAccountMessage> FindOne(int ChannelID, int AccountID, int MessageID)
    {
        return await _appDbContext.ChannelAccountMessages.FindAsync(ChannelID, AccountID, MessageID);
    }

    public async Task<ChannelAccountMessage> Update(ChannelAccountMessage updatedChannelAccountMessage)
    {
        _appDbContext.ChannelAccountMessages.Update(updatedChannelAccountMessage);
        await _appDbContext.SaveChangesAsync();
        return updatedChannelAccountMessage;
    }
}
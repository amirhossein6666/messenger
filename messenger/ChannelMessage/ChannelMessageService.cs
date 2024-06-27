using messenger;
using Microsoft.EntityFrameworkCore;

namespace  ChannelMessage;

public class ChannelMessageService
{
    private readonly AppDbContext _appDbContext;

    public ChannelMessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ChannelMessage> Create(ChannelMessage channelMessage)
    {
        _appDbContext.ChannelMessage.Add(channelMessage);
        await _appDbContext.SaveChangesAsync();
        return channelMessage;
    }

    public async Task<List<ChannelMessage>> FindAll()
    {
        return await _appDbContext.ChannelMessage.ToListAsync();
    }

    public async Task<ChannelMessage> FindOne(int ChannelID, int MessageID)
    {
        return await _appDbContext.ChannelMessage.FindAsync(ChannelID, MessageID);
    }
}
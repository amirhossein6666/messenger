using Microsoft.EntityFrameworkCore;

namespace messenger.ChannelMessage;

public class ChannelMessageService
{
    private readonly ChannelMessageDbContext _channelMessageDbContext;

    public ChannelMessageService(ChannelMessageDbContext channelMessageDbContext)
    {
        _channelMessageDbContext = channelMessageDbContext;
    }

    public async Task<ChannelMessage> Create(ChannelMessage channelMessage)
    {
        _channelMessageDbContext.ChannelMessage.Add(channelMessage);
        await _channelMessageDbContext.SaveChangesAsync();
        return channelMessage;
    }

    public async Task<List<ChannelMessage>> FindAll()
    {
        return await _channelMessageDbContext.ChannelMessage.ToListAsync();
    }

    public async Task<ChannelMessage> FindOne(int ChannelID, int MessageID)
    {
        return await _channelMessageDbContext.ChannelMessage.FindAsync(ChannelID, MessageID);
    }
}
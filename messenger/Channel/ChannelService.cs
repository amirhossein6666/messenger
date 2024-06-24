namespace  Channel;

using Microsoft.EntityFrameworkCore;

public class ChannelService
{
    private readonly ChannelDbContext _channelDbContext;

    public ChannelService(ChannelDbContext channelDbContext)
    {
        _channelDbContext = channelDbContext;
    }

    public async Task<Channel> Create(Channel channel)
    {
        _channelDbContext.Channel.Add(channel);
        await _channelDbContext.SaveChangesAsync();
        return channel;
    }

    public async Task<List<Channel>> FindAll()
    {
        return await _channelDbContext.Channel.ToListAsync();
    }

    public async Task<Channel> FindOne(int ID)
    {
        return await _channelDbContext.Channel.FindAsync(ID);
    }

    public async Task<Channel> Update(Channel updatedChannel)
    {
        _channelDbContext.Channel.Update(updatedChannel);
        await _channelDbContext.SaveChangesAsync();
        return updatedChannel;
    }
}
using messenger;

namespace  Channel;

using Microsoft.EntityFrameworkCore;

public class ChannelService
{
    private readonly AppDbContext _appDbContext;

    public ChannelService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Channel> Create(Channel channel)
    {
        _appDbContext.Channels.Add(channel);
        await _appDbContext.SaveChangesAsync();
        return channel;
    }

    public async Task<List<Channel>> FindAll()
    {
        return await _appDbContext.Channels.ToListAsync();
    }

    public async Task<Channel> FindOne(int ID)
    {
        return await _appDbContext.Channels.FindAsync(ID);
    }

    public async Task<Channel> Update(Channel updatedChannel)
    {
        _appDbContext.Channels.Update(updatedChannel);
        await _appDbContext.SaveChangesAsync();
        return updatedChannel;
    }
}
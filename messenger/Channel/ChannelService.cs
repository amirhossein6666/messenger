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
        _appDbContext.Channel.Add(channel);
        await _appDbContext.SaveChangesAsync();
        return channel;
    }

    public async Task<List<Channel>> FindAll()
    {
        return await _appDbContext.Channel.ToListAsync();
    }

    public async Task<Channel> FindOne(int ID)
    {
        return await _appDbContext.Channel.FindAsync(ID);
    }

    public async Task<Channel> Update(Channel updatedChannel)
    {
        _appDbContext.Channel.Update(updatedChannel);
        await _appDbContext.SaveChangesAsync();
        return updatedChannel;
    }
}
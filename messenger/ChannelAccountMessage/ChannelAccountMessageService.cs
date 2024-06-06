using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace messenger.ChannelAccountMessage;

public class ChannelAccountMessageService
{
    private readonly ChannelAccountMessageDbContext _channelAccountMessageDbContext;

    public ChannelAccountMessageService(ChannelAccountMessageDbContext channelAccountMessageDbContext)
    {
        _channelAccountMessageDbContext = channelAccountMessageDbContext;
    }

    public async Task<ChannelAccountMessage> Create(ChannelAccountMessage channelAccountMessage)
    {
        _channelAccountMessageDbContext.ChannelAccountMessage.Add(channelAccountMessage);
        await _channelAccountMessageDbContext.SaveChangesAsync();
        return channelAccountMessage;
    }

    public async Task<List<ChannelAccountMessage>> FindAll()
    {
        return await _channelAccountMessageDbContext.ChannelAccountMessage.ToListAsync();
    }

    public async Task<ChannelAccountMessage> FindOne(int ChannelID, int AccountID, int MessageID)
    {
        return await _channelAccountMessageDbContext.ChannelAccountMessage.FromSqlRaw("SELECT * FROM ChannelAccountMessage WHERE ChannelID = @ChannelID AND AccountID = @AccountID And MessageID = @MessageID",
                new SqlParameter("@ChannelID", ChannelID),
                new SqlParameter("@AccountID", AccountID),
                new SqlParameter("@MessageID", MessageID)).FirstOrDefaultAsync();
    }

    public async Task<ChannelAccountMessage> Update(ChannelAccountMessage updatedChannelAccountMessage)
    {
        _channelAccountMessageDbContext.ChannelAccountMessage.Update(updatedChannelAccountMessage);
        await _channelAccountMessageDbContext.SaveChangesAsync();
        return updatedChannelAccountMessage;
    }
}
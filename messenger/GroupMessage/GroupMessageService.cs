using Microsoft.EntityFrameworkCore;

namespace messenger.GroupMessage;

public class GroupMessageService
{
    private readonly GroupMessageDbContext _groupMessageDbContext;

    public GroupMessageService(GroupMessageDbContext groupMessageDbContext)
    {
        _groupMessageDbContext = groupMessageDbContext;
    }

    public async Task<GroupMessage> Create(GroupMessage groupMessage)
    {
        _groupMessageDbContext.GroupMessage.Add(groupMessage);
        await _groupMessageDbContext.SaveChangesAsync();
        return groupMessage;
    }

    public async Task<List<GroupMessage>> FindAll()
    {
        return await _groupMessageDbContext.GroupMessage.ToListAsync();
    }

    public async Task<GroupMessage> FindOne(int GroupID, int MessageID)
    {
        return await _groupMessageDbContext.GroupMessage.FindAsync(GroupID, MessageID);
    }

}
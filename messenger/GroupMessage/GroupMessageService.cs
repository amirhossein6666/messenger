using messenger;
using Microsoft.EntityFrameworkCore;

namespace  GroupMessage;

public class GroupMessageService
{
    private readonly AppDbContext _appDbContext;

    public GroupMessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<GroupMessage> Create(GroupMessage groupMessage)
    {
        _appDbContext.GroupMessages.Add(groupMessage);
        await _appDbContext.SaveChangesAsync();
        return groupMessage;
    }

    public async Task<List<GroupMessage>> FindAll()
    {
        return await _appDbContext.GroupMessages.ToListAsync();
    }

    public async Task<GroupMessage> FindOne(int GroupID, int MessageID)
    {
        return await _appDbContext.GroupMessages.FindAsync(GroupID, MessageID);
    }

}
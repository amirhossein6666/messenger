using messenger;
using Microsoft.EntityFrameworkCore;

namespace  GroupAccountMessage;

public class GroupAccountMessageService
{
    private readonly AppDbContext _appDbContext;

    public GroupAccountMessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<GroupAccountMessage> Create(GroupAccountMessage groupAccountMessage)
    {
        _appDbContext.GroupAccountMessage.Add(groupAccountMessage);
        await _appDbContext.SaveChangesAsync();
        return groupAccountMessage;
    }

    public async Task<List<GroupAccountMessage>> FindAll()
    {
        return await _appDbContext.GroupAccountMessage.ToListAsync();
    }

    public async Task<GroupAccountMessage> FindOne(int GroupID, int AccountID, int MessageID)
    {
        return await _appDbContext.GroupAccountMessage.FindAsync(GroupID, AccountID, MessageID);
    }

    public async Task<GroupAccountMessage> Update(GroupAccountMessage updatedGroupAccountMEssage)
    {
        _appDbContext.GroupAccountMessage.Update(updatedGroupAccountMEssage);
        await _appDbContext.SaveChangesAsync();
        return updatedGroupAccountMEssage;
    }

}
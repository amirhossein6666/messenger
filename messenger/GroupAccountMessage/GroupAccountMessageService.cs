using Microsoft.EntityFrameworkCore;

namespace  GroupAccountMessage;

public class GroupAccountMessageService
{
    private readonly GroupAccountMessageDbContext _groupAccountMessageDbContext;

    public GroupAccountMessageService(GroupAccountMessageDbContext groupAccountMessageDbContext)
    {
        _groupAccountMessageDbContext = groupAccountMessageDbContext;
    }

    public async Task<GroupAccountMessage> Create(GroupAccountMessage groupAccountMessage)
    {
        _groupAccountMessageDbContext.GroupAccountMessage.Add(groupAccountMessage);
        await _groupAccountMessageDbContext.SaveChangesAsync();
        return groupAccountMessage;
    }

    public async Task<List<GroupAccountMessage>> FindAll()
    {
        return await _groupAccountMessageDbContext.GroupAccountMessage.ToListAsync();
    }

    public async Task<GroupAccountMessage> FindOne(int GroupID, int AccountID, int MessageID)
    {
        return await _groupAccountMessageDbContext.GroupAccountMessage.FindAsync(GroupID, AccountID, MessageID);
    }

    public async Task<GroupAccountMessage> Update(GroupAccountMessage updatedGroupAccountMEssage)
    {
        _groupAccountMessageDbContext.GroupAccountMessage.Update(updatedGroupAccountMEssage);
        await _groupAccountMessageDbContext.SaveChangesAsync();
        return updatedGroupAccountMEssage;
    }

}
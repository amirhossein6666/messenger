using Microsoft.EntityFrameworkCore;

namespace  Group;

public class GroupService
{
    private readonly GroupDbContext _groupDbContext;

    public GroupService(GroupDbContext groupDbContext)
    {
        _groupDbContext = groupDbContext;
    }

    public async Task<Group> Create(Group group)
    {
        _groupDbContext.Group.Add(group);
        await _groupDbContext.SaveChangesAsync();
        return group;
    }

    public async Task<List<Group>> FindAll()
    {
        return await _groupDbContext.Group.ToListAsync();
    }

    public async Task<Group> FindOne(int ID)
    {
        return await _groupDbContext.Group.FindAsync(ID);
    }

    public async Task<Group> Update(Group updatedGroup)
    {
        _groupDbContext.Group.Update(updatedGroup);
        await _groupDbContext.SaveChangesAsync();
        return updatedGroup;
    }
}
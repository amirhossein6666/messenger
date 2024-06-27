using messenger;
using Microsoft.EntityFrameworkCore;

namespace  Group;

public class GroupService
{
    private readonly AppDbContext _appDbContext;

    public GroupService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Group> Create(Group group)
    {
        _appDbContext.Group.Add(group);
        await _appDbContext.SaveChangesAsync();
        return group;
    }

    public async Task<List<Group>> FindAll()
    {
        return await _appDbContext.Group.ToListAsync();
    }

    public async Task<Group> FindOne(int ID)
    {
        return await _appDbContext.Group.FindAsync(ID);
    }

    public async Task<Group> Update(Group updatedGroup)
    {
        _appDbContext.Group.Update(updatedGroup);
        await _appDbContext.SaveChangesAsync();
        return updatedGroup;
    }
}
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
        _appDbContext.Groups.Add(group);
        await _appDbContext.SaveChangesAsync();
        return group;
    }

    public async Task<List<Group>> FindAll()
    {
        return await _appDbContext.Groups.ToListAsync();
    }

    public async Task<Group> FindOne(int ID)
    {
        return await _appDbContext.Groups.FindAsync(ID);
    }

    public async Task<Group> Update(Group updatedGroup)
    {
        _appDbContext.Groups.Update(updatedGroup);
        await _appDbContext.SaveChangesAsync();
        return updatedGroup;
    }
}
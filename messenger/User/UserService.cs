using Microsoft.EntityFrameworkCore;

namespace messenger.User;

public class UserService
{
    private readonly UserDbContext _userDbContext;

    public UserService(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public async Task<User> Create(User user)
    {
        _userDbContext.User.Add(user);
        await _userDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> FindAll()
    {
        return await _userDbContext.User.ToListAsync();
    }

    public async Task<User> FindOne(int ID)
    {
        return await _userDbContext.User.FindAsync(ID);
    }

    public async Task<User> Update(User updateUser)
    {
        _userDbContext.User.Update(updateUser);
        await _userDbContext.SaveChangesAsync();
        return updateUser;
    }
}
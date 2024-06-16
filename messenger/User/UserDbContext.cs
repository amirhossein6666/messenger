using Microsoft.EntityFrameworkCore;

namespace messenger.User;

public class UserDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public UserDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }

    public DbSet<User> User { get; set; }

}
namespace  Group;
using Microsoft.EntityFrameworkCore;


public class GroupDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public GroupDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }

    public DbSet<Group> Group { get; set; }
}
using Microsoft.EntityFrameworkCore;

namespace messenger.Channel;

public class ChannelDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public ChannelDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }

    public DbSet<Channel> Channel { get; set; }
}
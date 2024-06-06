using Microsoft.EntityFrameworkCore;

namespace messenger.ChannelAccountMessage;

public class ChannelAccountMessageDbContext : DbContext
{
    public IConfiguration _config { get; set; }
    public ChannelAccountMessageDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChannelAccountMessage>()
            .HasKey(ac => new { ac.AccountID, ac.ChannelID });
    }

    public DbSet<ChannelAccountMessage> ChannelAccountMessage { get; set; }

}
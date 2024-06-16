using Microsoft.EntityFrameworkCore;

namespace messenger.GroupMessage;

public class GroupMessageDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public GroupMessageDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupMessage>()
            .HasKey(ac => new { ac.GroupID, ac.MessageID });
    }

    public DbSet<GroupMessage> GroupMessage { get; set; }

}
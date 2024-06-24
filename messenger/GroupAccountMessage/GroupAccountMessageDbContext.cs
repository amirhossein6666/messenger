using Microsoft.EntityFrameworkCore;

namespace  GroupAccountMessage;

public class GroupAccountMessageDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public GroupAccountMessageDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupAccountMessage>()
            .HasKey(ac => new { ac.GroupID, ac.AccountID, ac.MessageID });
    }

    public DbSet<GroupAccountMessage> GroupAccountMessage { get; set; }

}
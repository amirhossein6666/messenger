using Microsoft.EntityFrameworkCore;

namespace  GroupMessage;

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

        modelBuilder.Entity<GroupMessage>()
            .HasOne(gm => gm.Group)
            .WithMany(g => g.GroupMessages)
            .HasForeignKey(gm => gm.GroupID);

        modelBuilder.Entity<GroupMessage>()
            .HasOne(gm => gm.Message)
            .WithMany(m => m.GroupMessages)
            .HasForeignKey(gm => gm.MessageID);
    }

    public DbSet<GroupMessage> GroupMessage { get; set; }

}
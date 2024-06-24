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

        modelBuilder.Entity<GroupAccountMessage>()
            .HasOne(gam => gam.Group)
            .WithMany(c => c.GroupAccountMessages)
            .HasForeignKey(gam => gam.GroupID);

        modelBuilder.Entity<GroupAccountMessage>()
            .HasOne(gam => gam.Account)
            .WithMany(c => c.GroupAccountMessages)
            .HasForeignKey(ag => ag.AccountID);

        modelBuilder.Entity<GroupAccountMessage>()
            .HasOne(cam => cam.Message)
            .WithMany(c => c.GroupAccountMessages)
            .HasForeignKey(ag => ag.MessageID);
    }

    public DbSet<GroupAccountMessage> GroupAccountMessage { get; set; }

}
using Microsoft.EntityFrameworkCore;

namespace ChannelAccountMessage;

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
            .HasKey(ac => new { ac.ChannelID, ac.AccountID, ac.MessageID });

        modelBuilder.Entity<ChannelAccountMessage>()
            .HasOne(cam => cam.Channel)
            .WithMany(c => c.ChannelAccountMessages)
            .HasForeignKey(ag => ag.ChannelID);

        modelBuilder.Entity<ChannelAccountMessage>()
            .HasOne(cam => cam.Account)
            .WithMany(c => c.ChannelAccountMessages)
            .HasForeignKey(ag => ag.AccountID);

        modelBuilder.Entity<ChannelAccountMessage>()
            .HasOne(cam => cam.Message)
            .WithMany(c => c.ChannelAccountMessages)
            .HasForeignKey(ag => ag.MessageID);
    }

    public DbSet<ChannelAccountMessage> ChannelAccountMessage { get; set; }
}
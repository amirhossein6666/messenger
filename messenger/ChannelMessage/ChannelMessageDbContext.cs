using Microsoft.EntityFrameworkCore;

namespace  ChannelMessage;

public class ChannelMessageDbContext : DbContext
{
    public IConfiguration _config { get; set; }
    public ChannelMessageDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChannelMessage>()
            .HasKey(ac => new { ac.ChannelID, ac.MessageID });

        modelBuilder.Entity<ChannelMessage>()
            .HasOne(ag => ag.Channel)
            .WithMany(a => a.ChannelMessages)
            .HasForeignKey(ag => ag.ChannelID);

        modelBuilder.Entity<ChannelMessage>()
            .HasOne(ag => ag.Message)
            .WithMany(a => a.ChannelMessages)
            .HasForeignKey(ag => ag.MessageID);
    }

    public DbSet<ChannelMessage> ChannelMessage { get; set; }

}
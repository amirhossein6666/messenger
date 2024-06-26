using Microsoft.EntityFrameworkCore;

namespace  AccountChannel;

public class AccountChannelDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public AccountChannelDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountChannel>()
            .HasKey(ac => new { ac.AccountID, ac.ChannelID });

        modelBuilder.Entity<AccountChannel>()
            .HasOne(ac => ac.Account)
            .WithMany(a => a.AccountChannels)
            .HasForeignKey(ag => ag.AccountID);

        modelBuilder.Entity<AccountChannel>()
            .HasOne(ac => ac.Channel)
            .WithMany(c => c.AccountChannels)
            .HasForeignKey(ag => ag.ChannelID);
    }

    public DbSet<AccountChannel> AccountChannel { get; set; }
}
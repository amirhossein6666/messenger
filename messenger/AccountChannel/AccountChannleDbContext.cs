using Microsoft.EntityFrameworkCore;

namespace messenger.AccountChannel;

public class AccountChannleDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public AccountChannleDbContext(IConfiguration config)
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
    }

    public DbSet<AccountChannel> AccountChannel { get; set; }
}
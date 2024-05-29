using Microsoft.EntityFrameworkCore;

namespace messenger.AccountContact;

public class AccountContactDbContext : DbContext
{
    public IConfiguration _config { get; set; }
    public AccountContactDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountContact>()
            .HasKey(ac => new { ac.AccountID, ac.ContactID });
    }

    public DbSet<AccountContact> AccountContact { get; set; }
}
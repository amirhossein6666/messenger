using Microsoft.EntityFrameworkCore;

namespace messenger.AccountPV;

public class AccountPVDbContext : DbContext
{
    public IConfiguration _config { get; set; }
    public AccountPVDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountPV>()
            .HasKey(ac => new { ac.AccountID, ac.PVID });
    }

    public DbSet<AccountPV> AccountPV { get; set; }
}
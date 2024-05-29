using Microsoft.EntityFrameworkCore;

namespace messenger.AccountGroup;

public class AccountGroupDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public AccountGroupDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountGroup>()
            .HasKey(ac => new { ac.AccountID, ac.GroupID });
    }

    public DbSet<AccountGroup> AccountGroup { get; set; }
}
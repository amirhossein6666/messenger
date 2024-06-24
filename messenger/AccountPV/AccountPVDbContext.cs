using Microsoft.EntityFrameworkCore;

namespace  AccountPV;

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

        modelBuilder.Entity<AccountPV>()
            .HasOne(ap => ap.Pv)
            .WithMany(p => p.AccountPvs)
            .HasForeignKey(ap => ap.PVID);

        modelBuilder.Entity<AccountPV>()
            .HasOne(ap => ap.Account)
            .WithMany(a => a.AccountPvs)
            .HasForeignKey(ap => ap.AccountID);
    }

    public DbSet<AccountPV> AccountPV { get; set; }
}
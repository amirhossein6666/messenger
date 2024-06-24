using Microsoft.EntityFrameworkCore;

namespace  AccountContact;

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

        modelBuilder.Entity<AccountContact>()
            .HasOne(ac => ac.Account)
            .WithMany(a => a.AccountContacts)
            .HasForeignKey(ac => ac.AccountID);

        modelBuilder.Entity<AccountContact>()
            .HasOne(ac => ac.Contact)
            .WithMany(a => a.AccountContacts)
            .HasForeignKey(ac => ac.ContactID);
    }

    public DbSet<AccountContact> AccountContact { get; set; }
}
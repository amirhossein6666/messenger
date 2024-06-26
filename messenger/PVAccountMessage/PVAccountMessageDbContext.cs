using Microsoft.EntityFrameworkCore;

namespace  PVAccountMessage;

public class PVAccountMessageDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public PVAccountMessageDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PVAccountMessage>()
            .HasKey(ac => new { ac.PVID, ac.AccountID, ac.MessageID });

        modelBuilder.Entity<PVAccountMessage>()
            .HasOne(pam => pam.PV)
            .WithMany(c => c.PvAccountMessages)
            .HasForeignKey(pam => pam.PVID);

        modelBuilder.Entity<PVAccountMessage>()
            .HasOne(pam => pam.Account)
            .WithMany(c => c.PvAccountMessages)
            .HasForeignKey(pam => pam.AccountID);

        modelBuilder.Entity<PVAccountMessage>()
            .HasOne(pam => pam.Message)
            .WithMany(c => c.PvAccountMessages)
            .HasForeignKey(pam => pam.MessageID);
    }

    public DbSet<PVAccountMessage> PvAccountMessage { get; set; }
}
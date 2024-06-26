using Microsoft.EntityFrameworkCore;

namespace messenger.PVMessage;

public class PVMessageDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public PVMessageDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PVMessage>()
            .HasKey(ac => new { ac.PVID, ac.MessageID });

        modelBuilder.Entity<PVMessage>()
            .HasOne(pv => pv.PV)
            .WithMany(m => m.PvMessages)
            .HasForeignKey(pv => pv.PVID);

        modelBuilder.Entity<PVMessage>()
            .HasOne(g => g.Message)
            .WithMany(m => m.PvMessages)
            .HasForeignKey(pm => pm.MessageID);
    }

    public DbSet<PVMessage> PVMessages { get; set; }

}
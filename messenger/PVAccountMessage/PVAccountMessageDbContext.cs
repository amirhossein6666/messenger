using Microsoft.EntityFrameworkCore;

namespace messenger.PVAccountMessage;

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
    }

    public DbSet<PVAccountMessage> PvAccountMessage { get; set; }
}
using Microsoft.EntityFrameworkCore;

namespace  PV;

public class PVDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public PVDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }

    public DbSet<PV> PV { get; set; }
}
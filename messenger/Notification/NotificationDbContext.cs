using Microsoft.EntityFrameworkCore;

namespace  Notification;

public class NotificationDbContext : DbContext
{
    public IConfiguration _config { get; set; }
    public NotificationDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }

    public DbSet<Notification> Notification { get; set; }
}
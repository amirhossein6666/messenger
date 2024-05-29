using Microsoft.EntityFrameworkCore;

namespace messenger.Message;

public class MessageDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public MessageDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }

    public DbSet<Message> Message { get; set; }
}
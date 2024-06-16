using Microsoft.EntityFrameworkCore;

namespace messenger.MessageReply;

public class MessageReplyDbContext: DbContext
{
    public IConfiguration _config { get; set; }
    public MessageReplyDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MessageReply>()
            .HasKey(ac => new { ac.MessageID, ac.replyID });
    }


    public DbSet<MessageReply> MessageReply { get; set; }
}
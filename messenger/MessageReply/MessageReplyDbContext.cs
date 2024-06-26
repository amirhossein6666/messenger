using Microsoft.EntityFrameworkCore;

namespace MessageReply;

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
            .HasKey(ac => new { ac.MessageID, ac.ReplyID });

        modelBuilder.Entity<MessageReply>()
            .HasOne(mr => mr.Message)
            .WithMany(m => m.MessageReplies)
            .HasForeignKey(mr => mr.MessageID);

        modelBuilder.Entity<MessageReply>()
            .HasOne(mr => mr.Reply)
            .WithMany(m => m.MessageReplies)
            .HasForeignKey(mr => mr.ReplyID);
    }


    public DbSet<MessageReply> MessageReply { get; set; }
}
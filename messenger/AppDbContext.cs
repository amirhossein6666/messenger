using Microsoft.EntityFrameworkCore;

namespace messenger;

public class AppDbContext: DbContext
{

    public IConfiguration _config { get; set; }
    public AppDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // set up  relation between Account and its contacts
        modelBuilder.Entity<AccountContact.AccountContact>()
            .HasKey(e => new { e.AccountID, e.ContactID });

        modelBuilder.Entity<AccountContact.AccountContact>()
            .HasOne(e => e.Account)
            .WithMany(s => s.Contacts)
            .HasForeignKey(e => e.AccountID);

        modelBuilder.Entity<AccountContact.AccountContact>()
            .HasOne(e => e.Contact)
            .WithMany(s => s.ContactedBy)
            .HasForeignKey(e => e.ContactID);

        // determine keys of AccountChannel
        modelBuilder.Entity<AccountChannel.AccountChannel>()
            .HasKey(e => new { e.AccountID, e.ChannelID });

        // determine keys of AccountGroup
        modelBuilder.Entity<AccountGroup.AccountGroup>()
            .HasKey(e => new { e.AccountID, e.GroupID });

        // determine keys of AccountPV
        modelBuilder.Entity<AccountPV.AccountPV>()
            .HasKey(e => new { e.AccountID, e.PVID });

        // determine keys of AccountPV
        modelBuilder.Entity<ChannelAccountMessage.ChannelAccountMessage>()
            .HasKey(e => new { e.ChannelID, e.AccountID, e.MessageID });

        // determine keys of AccountPV
        modelBuilder.Entity<ChannelMessage.ChannelMessage>()
            .HasKey(e => new { e.ChannelID, e.MessageID });

        // determine keys of AccountPV
        modelBuilder.Entity<GroupAccountMessage.GroupAccountMessage>()
            .HasKey(e => new { e.GroupID, e.MessageID });



    }


    public DbSet<Account.Account> Account { get; set; }
    public DbSet<AccountChannel.AccountChannel> AccountChannel { get; set; }
    public DbSet<AccountContact.AccountContact> AccountContact { get; set; }
    public DbSet<AccountGroup.AccountGroup> AccountGroup { get; set; }
    public DbSet<AccountPV.AccountPV> AccountPV { get; set; }
    public DbSet<Channel.Channel> Channel { get; set; }
    public DbSet<ChannelAccountMessage.ChannelAccountMessage> ChannelAccountMessage { get; set; }
    public DbSet<ChannelMessage.ChannelMessage> ChannelMessage { get; set; }
    public DbSet<Group.Group> Group { get; set; }
    public DbSet<GroupAccountMessage.GroupAccountMessage> GroupAccountMessage { get; set; }
    public DbSet<GroupMessage.GroupMessage> GroupMessage { get; set; }
    public DbSet<Message.Message> Message { get; set; }
    public DbSet<Notification.Notification> Notification { get; set; }
    public DbSet<PV.PV> PV { get; set; }
    public DbSet<PVAccountMessage.PVAccountMessage> PVAccountMessage { get; set; }
    public DbSet<PVMessage.PVMessage> PVMessage { get; set; }
    public DbSet<User.User> User { get; set; }

}
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
        // Additional configurations

        // determine keys of AccountGroup
        modelBuilder.Entity<AccountGroup.AccountGroup>()
            .HasKey(e => new { e.AccountID, e.GroupID });

        // determine keys of AccountPV
        modelBuilder.Entity<AccountPV.AccountPV>()
            .HasKey(e => new { e.AccountID, e.PVID });

        // determine keys of ChannelAccountMessage
        modelBuilder.Entity<ChannelAccountMessage.ChannelAccountMessage>()
            .HasKey(e => new { e.ChannelID, e.AccountID, e.MessageID });

        // determine keys of ChannelMessage
        modelBuilder.Entity<ChannelMessage.ChannelMessage>()
            .HasKey(e => new { e.ChannelID, e.MessageID });

        // determine keys of GroupAccountMessage
        modelBuilder.Entity<GroupAccountMessage.GroupAccountMessage>()
            .HasKey(e => new { e.GroupID, e.AccountID, e.MessageID });

        // determine keys of GroupMessage
        modelBuilder.Entity<GroupMessage.GroupMessage>()
            .HasKey(e => new { e.GroupID, e.MessageID });

        // determine keys of GroupMessage
        modelBuilder.Entity<PVAccountMessage.PVAccountMessage>()
            .HasKey(e => new { e.PVID, e.AccountID, e.MessageID });

        // determine keys of GroupMessage
        modelBuilder.Entity<PVMessage.PVMessage>()
            .HasKey(e => new { e.PVID, e.MessageID });

        // set up  relation between message and its Account sender
        modelBuilder.Entity<Message.Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.senderID)
            .OnDelete(DeleteBehavior.Restrict);

        // set up  relation between pv and its participants
        modelBuilder.Entity<PV.PV>()
            .HasOne(m => m.personOneAccount)
            .WithMany()
            .HasForeignKey(m => m.personOneID)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<PV.PV>()
            .HasOne(m => m.personTwoAccount)
            .WithMany()
            .HasForeignKey(m => m.personTwoID)
            .OnDelete(DeleteBehavior.Restrict);

    }


    public DbSet<Account.Account> Accounts { get; set; }
    public DbSet<AccountChannel.AccountChannel> AccountChannels { get; set; }
    public DbSet<AccountContact.AccountContact> AccountContacts { get; set; }
    public DbSet<AccountGroup.AccountGroup> AccountGroups { get; set; }
    public DbSet<AccountPV.AccountPV> AccountPVs { get; set; }
    public DbSet<Channel.Channel> Channels { get; set; }
    public DbSet<ChannelAccountMessage.ChannelAccountMessage> ChannelAccountMessages { get; set; }
    public DbSet<ChannelMessage.ChannelMessage> ChannelMessages { get; set; }
    public DbSet<Group.Group> Groups { get; set; }
    public DbSet<GroupAccountMessage.GroupAccountMessage> GroupAccountMessages { get; set; }
    public DbSet<GroupMessage.GroupMessage> GroupMessages { get; set; }
    public DbSet<Message.Message> Messages { get; set; }
    public DbSet<Notification.Notification> Notifications { get; set; }
    public DbSet<PV.PV> PVs { get; set; }
    public DbSet<PVAccountMessage.PVAccountMessage> PVAccountMessages { get; set; }
    public DbSet<PVMessage.PVMessage> PVMessages { get; set; }
    public DbSet<User.User> Users { get; set; }

}
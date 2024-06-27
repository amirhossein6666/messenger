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
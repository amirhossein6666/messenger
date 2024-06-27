using System.ComponentModel.DataAnnotations.Schema;

namespace Account;

public class Account
{
    public int? ID { get; set; }
    public string name { get; set; }
    public string accountID { get; set; }
    public string? profile { get; set; }
    public int userID { get; set; }
    public bool? isOnline { get; set; }
    public DateTime lastSeen { get; set; }

    public ICollection<AccountPV.AccountPV> AccountPvs { get; set; }
    public ICollection<PV.PV> Pvs { get; set; }

    public ICollection<AccountGroup.AccountGroup> AccountGroups { get; set; }
    public ICollection<Group.Group> Groups { get; set; }

    public ICollection<AccountChannel.AccountChannel> AccountChannels { get; set; }
    public ICollection<Channel.Channel> Channels { get; set; }
    
    public ICollection<AccountContact.AccountContact> Contacts { get; set; } = new List<AccountContact.AccountContact>();
    public ICollection<AccountContact.AccountContact> ContactedBy { get; set; }


    public ICollection<ChannelAccountMessage.ChannelAccountMessage> ChannelAccountMessages { get; set; }

    public ICollection<GroupAccountMessage.GroupAccountMessage> GroupAccountMessages { get; set; }

    public ICollection<PVAccountMessage.PVAccountMessage> PvAccountMessages { get; set; }

}
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

    public ICollection<AccountContact.AccountContact> AccountContacts { get; set; }
    public ICollection<Account> Contacts { get; set; }
    public ICollection<Account> ContactsOF { get; set; }


}
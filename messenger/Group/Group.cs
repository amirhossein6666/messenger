namespace  Group;

public class Group
{
    public int? ID { get; set; }
    public string name { get; set; }
    public string? profile { get; set; }
    public string GroupID { get; set; }
    public int? messagesNumber { get; set; } = 0;

    public ICollection<AccountGroup.AccountGroup> AccountGroups { get; set; }
    public ICollection<Account.Account> members { get; set; }
}
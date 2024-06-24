namespace  AccountGroup;

public class AccountGroup
{
    public int AccountID { get; set; }
    public Account.Account Account { get; set; }

    public int GroupID { get; set; }
    public Group.Group Group { get; set; }

    public string role { get; set; }

}
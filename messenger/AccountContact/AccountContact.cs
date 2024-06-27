namespace  AccountContact;

public class AccountContact
{
    public int AccountID { get; set; }
    public Account.Account Account { get; set; }

    public int ContactID { get; set; }
    public Account.Account Contact { get; set; }

    public bool closeFriend { get; set; }
}
namespace User;

public class User
{
    public int? ID { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }

    // start configuring one-to-many relationship
    public ICollection<Account.Account> Accounts { get; set; }
}
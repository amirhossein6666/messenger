namespace messenger.Account;

public class Account
{
    public int? ID { get; set; }
    public string name { get; set; }
    public string accountID { get; set; }
    public string? profile { get; set; }
    public int userID { get; set; }
    public bool? isOnline { get; set; }
    public DateTime lastSeen { get; set; }
}
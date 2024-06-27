namespace  AccountChannel;

public class AccountChannel
{
    public int AccountID { get; set; }
    public Account.Account Account { get; set; }

    public int ChannelID { get; set; }
    public Channel.Channel Channel { get; set; }

    public string role { get; set; }
}
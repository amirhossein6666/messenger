namespace  Channel;

public class Channel
{
    public int? ID { get; set; }
    public string name { get; set; }
    public string? profile { get; set; }
    public string channelID { get; set; }
    public int messagesNumber  { get; set; }

    public ICollection<AccountChannel.AccountChannel> AccountChannels { get; set; }
    public ICollection<Account.Account> members { get; set; }

    public ICollection<ChannelAccountMessage.ChannelAccountMessage> ChannelAccountMessages { get; set; }

    public ICollection<ChannelMessage.ChannelMessage> ChannelMessages { get; set; }
    public ICollection<Message.Message> messages { get; set; }
}
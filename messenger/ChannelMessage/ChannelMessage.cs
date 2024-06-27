namespace  ChannelMessage;

public class ChannelMessage
{
    public int ChannelID { get; set; }
    public Channel.Channel Channel { get; set; }

    public int MessageID { get; set; }
    public Message.Message Message { get; set; }
}
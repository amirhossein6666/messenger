namespace  MessageReply;

public class MessageReply
{
    public int MessageID { get; set; }
    public Message.Message Message { get; set; }

    public int ReplyID { get; set; }
    public Message.Message Reply { get; set; }
}

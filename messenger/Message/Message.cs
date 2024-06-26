namespace  Message;

public class Message
{
    public int? ID { get; set; }
    public string text { get; set; }
    public DateTime sendDate { get; set; }
    public int senderID { get; set; }
    public bool isUpdated { get; set; }
    public DateTime? updateDate { get; set; } = DateTime.Now;

    public ICollection<ChannelAccountMessage.ChannelAccountMessage> ChannelAccountMessages { get; set; }

    public ICollection<ChannelMessage.ChannelMessage> ChannelMessages { get; set; }

    public ICollection<GroupAccountMessage.GroupAccountMessage> GroupAccountMessages { get; set; }

    public ICollection<GroupMessage.GroupMessage> GroupMessages { get; set; }

    public ICollection<MessageReply.MessageReply> MessageReplies { get; set; }
    public ICollection<Message> Replies { get; set; }
    public ICollection<Message> ReplyOf { get; set; } // the message that current message is its reply

    public ICollection<PVAccountMessage.PVAccountMessage> PvAccountMessages { get; set; }


}
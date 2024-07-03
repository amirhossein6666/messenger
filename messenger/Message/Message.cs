using messenger.PVMessage;

namespace  Message;

public class Message
{
    public int? ID { get; set; }
    public string text { get; set; }
    public DateTime sendDate { get; set; }
    public int senderID { get; set; }
    public bool isUpdated { get; set; }
    public DateTime? updateDate { get; set; } = DateTime.Now;
    public int? ReplyOF { get; set; }

    public ICollection<ChannelAccountMessage.ChannelAccountMessage> ChannelAccountMessages { get; set; }

    public ICollection<ChannelMessage.ChannelMessage> ChannelMessages { get; set; }

    public ICollection<GroupAccountMessage.GroupAccountMessage> GroupAccountMessages { get; set; }

    public ICollection<GroupMessage.GroupMessage> GroupMessages { get; set; }

    public ICollection<PVAccountMessage.PVAccountMessage> PvAccountMessages { get; set; }

    public ICollection<PVMessage> PvMessages { get; set; }


}
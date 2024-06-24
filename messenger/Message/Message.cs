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

}
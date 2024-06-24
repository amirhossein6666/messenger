using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  ChannelAccountMessage;

public class ChannelAccountMessage
{
    public int ChannelID { get; set; }
    public Channel.Channel Channel { get; set; }

    public int AccountID { get; set; }
    public Account.Account Account { get; set; }

    public int MessageID { get; set; }
    public Message.Message Message { get; set; }

    public bool isRead { get; set; } = false;
    public DateTime? receiveTime { get; set; }
    public DateTime? seenTime { get; set; }
}
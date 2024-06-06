using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace messenger.ChannelAccountMessage;

public class ChannelAccountMessage
{
    [Key] [Column(Order = 0)]
    public int ChannelID { get; set; }
    [Key] [Column(Order = 1)]
    public int AccountID { get; set; }
    [Key] [Column(Order = 2)]
    public int MessageID { get; set; }
    public bool isRead { get; set; } = false;
    public DateTime? receiveTime { get; set; }
    public DateTime? seenTime { get; set; }
}
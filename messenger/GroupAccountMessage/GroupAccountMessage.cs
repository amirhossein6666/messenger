namespace  GroupAccountMessage;

public class GroupAccountMessage
{
    public int GroupID { get; set; }
    public int AccountID { get; set; }
    public int MessageID { get; set; }
    public bool isRead { get; set; } = false;
    public DateTime? receiveTime { get; set; }
    public DateTime? seenTime { get; set; }
}
namespace  PVAccountMessage;

public class PVAccountMessage
{
    public int PVID { get; set; }
    public PV.PV PV { get; set; }

    public int AccountID { get; set; }
    public Account.Account Account { get; set; }

    public int MessageID { get; set; }
    public Message.Message Message { get; set; }

    public bool isRead { get; set; } = false;
    public DateTime? receiveTime { get; set; }
    public DateTime? seenTime { get; set; }
}
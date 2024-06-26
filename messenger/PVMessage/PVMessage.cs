namespace messenger.PVMessage;

public class PVMessage
{
    public int PVID { get; set; }
    public PV.PV PV { get; set; }

    public int MessageID { get; set; }
    public Message.Message Message { get; set; }
}
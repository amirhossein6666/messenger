using messenger.PVMessage;

namespace  PV;

public class PV
{
    public int? ID { get; set; }
    public int personOneID { get; set; }
    public int personTwoID { get; set; }
    public int messagesNumber { get; set; } = 0;

    public ICollection<AccountPV.AccountPV> AccountPvs { get; set; }

    public ICollection<PVAccountMessage.PVAccountMessage> PvAccountMessages { get; set; }

    public ICollection<PVMessage> PvMessages { get; set; }

}
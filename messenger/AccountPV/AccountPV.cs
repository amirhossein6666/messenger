namespace  AccountPV;

public class AccountPV
{
    public int AccountID { get; set; }
    public Account.Account Account { get; set; }

    public int PVID { get; set; }
    public PV.PV Pv { get; set; }

    public int partnerID { get; set; }

}
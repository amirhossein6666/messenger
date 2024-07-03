namespace  Notification;

public class Notification
{
    public int? ID { get; set; }

    public int AccountID { get; set; }
    public Account.Account Account { get; set; }

    public string ChatType { get; set; }
    public int ChatID { get; set; }
    public string text { get; set; }
    public DateTime sendTime { get; set; }
    public DateTime? receiveTime { get; set; }

}
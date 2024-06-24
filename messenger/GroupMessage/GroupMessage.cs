namespace  GroupMessage;

public class GroupMessage
{
     public int GroupID { get; set; }
     public Group.Group Group { get; set; }

     public int MessageID { get; set; }
     public Message.Message Message { get; set; }
}
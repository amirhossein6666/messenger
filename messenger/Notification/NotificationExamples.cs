using Swashbuckle.AspNetCore.Filters;

namespace Notification;

public class NotificationExamples: IMultipleExamplesProvider<Notification>
{
    public IEnumerable<SwaggerExample<Notification>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new Notification()
            {
                ID = null,
                AccountID = 1,
                ChatType = "PV",
                ChatID = 1,
                text = "new message from Amir",
                sendTime = DateTime.Now,
                receiveTime = null
            }
        );
    }
}
using Swashbuckle.AspNetCore.Filters;

namespace  Message;

public class MessageExamples: IMultipleExamplesProvider<Message>
{
    public IEnumerable<SwaggerExample<Message>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new Message()
            {
                ID = null,
                text = "messages body",
                isUpdated = false,
                sendDate = DateTime.Now,
                updateDate = null,
                senderID = 1,
            }
        );
    }
}
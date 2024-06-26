using Swashbuckle.AspNetCore.Filters;

namespace  MessageReply;

public class MessageReplyExamples : IMultipleExamplesProvider<MessageReply>
{
    public IEnumerable<SwaggerExample<MessageReply>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new MessageReply()
            {
                MessageID = 1,
                ReplyID = 1,
            }
        );
    }
}
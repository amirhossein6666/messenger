using Swashbuckle.AspNetCore.Filters;

namespace messenger.MessageReply;

public class MessageReplyExamples : IMultipleExamplesProvider<MessageReply>
{
    public IEnumerable<SwaggerExample<MessageReply>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new MessageReply()
            {
                MessageID = 1,
                replyID = 1,
            }
        );
    }
}
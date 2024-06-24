using Swashbuckle.AspNetCore.Filters;

namespace  ChannelAccountMessage;

public class ChannelAccountMessageExample: IMultipleExamplesProvider<ChannelAccountMessage>
{
    public IEnumerable<SwaggerExample<ChannelAccountMessage>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new ChannelAccountMessage()
            {
                AccountID = 1,
                ChannelID = 1,
                MessageID = 1,
                isRead = false,
                receiveTime = null,
                seenTime = null,
            }
        );
    }
}
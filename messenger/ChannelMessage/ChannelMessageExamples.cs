using Swashbuckle.AspNetCore.Filters;

namespace messenger.ChannelMessage;

public class ChannelMessageExamples: IMultipleExamplesProvider<ChannelMessage>
{
    public IEnumerable<SwaggerExample<ChannelMessage>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new ChannelMessage()
            {
                ChannelID = 1,
                MessageID = 1,
            }
        );
    }
}
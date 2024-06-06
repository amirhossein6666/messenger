using Swashbuckle.AspNetCore.Filters;

namespace messenger.Channel;

public class ChannelExamples: IMultipleExamplesProvider<Channel>
{
    public IEnumerable<SwaggerExample<Channel>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new Channel()
            {
                ID = null,
                name = "channel1",
                profile = null,
                channelID = "uniqueID",
                messagesNumber = 0,
            }
        );
    }
}
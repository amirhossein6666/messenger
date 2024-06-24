using Swashbuckle.AspNetCore.Filters;

namespace  GroupAccountMessage;

public class GroupAccountMessageExamples: IMultipleExamplesProvider<GroupAccountMessage>
{
    public IEnumerable<SwaggerExample<GroupAccountMessage>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new GroupAccountMessage()
            {
                AccountID = 1,
                GroupID = 1,
                MessageID = 1,
                isRead = false,
                receiveTime = null,
                seenTime = null,
            }
        );
    }
}
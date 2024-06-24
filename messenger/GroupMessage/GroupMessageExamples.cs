using Swashbuckle.AspNetCore.Filters;

namespace  GroupMessage;

public class GroupMessageExamples: IMultipleExamplesProvider<GroupMessage>
{
    public IEnumerable<SwaggerExample<GroupMessage>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new GroupMessage()
            {
                GroupID = 1,
                MessageID = 1,
            }
        );
    }
}
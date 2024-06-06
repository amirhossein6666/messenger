using Swashbuckle.AspNetCore.Filters;

namespace messenger.Group;

public class GroupExamples: IMultipleExamplesProvider<Group>
{
    public IEnumerable<SwaggerExample<Group>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new Group()
            {
                ID = null,
                GroupID = "uniqueID",
                name = "group1",
                profile = null,
                messagesNumber = 0,
            }
        );
    }
}
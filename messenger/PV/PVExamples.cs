using Swashbuckle.AspNetCore.Filters;

namespace messenger.PV;

public class PVExamples: IMultipleExamplesProvider<PV>
{
    public IEnumerable<SwaggerExample<PV>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new PV()
            {
                ID = null,
                personOneID = 1,
                personTwoID = 2,
                messagesNumber = 0
            }
        );
    }
}
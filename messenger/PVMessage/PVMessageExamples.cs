using Swashbuckle.AspNetCore.Filters;

namespace messenger.PVMessage;

public class PVMessageExamples: IMultipleExamplesProvider<PVMessage>
{
    public IEnumerable<SwaggerExample<PVMessage>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new PVMessage()
            {
                PVID = 1,
                MessageID = 1,
            }
        );
    }
}
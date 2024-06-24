using Swashbuckle.AspNetCore.Filters;

namespace  PVAccountMessage;

public class PVAccountMessageExamples: IMultipleExamplesProvider<PVAccountMessage>
{
    public IEnumerable<SwaggerExample<PVAccountMessage>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new PVAccountMessage()
            {
                AccountID = 1,
                PVID = 1,
                MessageID = 1,
                isRead = false,
                receiveTime = null,
                seenTime = null,
            }
        );
    }
}
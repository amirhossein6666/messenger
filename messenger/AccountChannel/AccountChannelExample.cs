using Swashbuckle.AspNetCore.Filters;

namespace messenger.AccountChannel;

public class AccountChannelExample: IMultipleExamplesProvider<AccountChannel>
{
    public IEnumerable<SwaggerExample<AccountChannel>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new AccountChannel()
            {
                AccountID = 1,
                ChannelID = 1,
                role = "member"
            }
        );
    }
}
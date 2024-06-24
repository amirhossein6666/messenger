using Swashbuckle.AspNetCore.Filters;

namespace  AccountGroup;

public class AccountGroupExamples: IMultipleExamplesProvider<AccountGroup>
{
    public IEnumerable<SwaggerExample<AccountGroup>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new AccountGroup()
            {
                AccountID = 1,
                GroupID = 1,
                role = "member"
            }
        );
    }
}
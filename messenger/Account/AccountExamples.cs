using Swashbuckle.AspNetCore.Filters;

namespace  Account;

public class AccountExamples: IMultipleExamplesProvider<Account>
{
    public IEnumerable<SwaggerExample<Account>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new Account()
            {
                ID = null,
                profile = null,
                isOnline = false,
                lastSeen = DateTime.Now,
                name = "account1",
                accountID = "uniqueID",
                userID = 1,
            }
        );
    }
}
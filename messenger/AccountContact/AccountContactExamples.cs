using Swashbuckle.AspNetCore.Filters;

namespace messenger.AccountContact;

public class AccountContactExamples: IMultipleExamplesProvider<AccountContact>
{
    public IEnumerable<SwaggerExample<AccountContact>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new AccountContact()
            {
                AccountID = 1,
                ContactID = 2,
                closeFriend = false
            }
        );
    }
}
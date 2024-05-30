using Swashbuckle.AspNetCore.Filters;

namespace messenger.AccountPV;

public class AccountPVExamples : IMultipleExamplesProvider<AccountPV>
{
    public IEnumerable<SwaggerExample<AccountPV>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "first",
            new AccountPV()
            {
                AccountID = 1,
                partnerID = 3,
                PVID = 3
            }
        );
    }
}
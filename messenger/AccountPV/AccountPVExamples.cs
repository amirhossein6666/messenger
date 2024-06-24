using Swashbuckle.AspNetCore.Filters;

namespace  AccountPV;

public class AccountPVExamples : IMultipleExamplesProvider<AccountPV>
{
    public IEnumerable<SwaggerExample<AccountPV>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new AccountPV()
            {
                AccountID = 3,
                partnerID = 4,
                PVID = 2
            }
        );
    }
}
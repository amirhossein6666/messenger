using Swashbuckle.AspNetCore.Filters;

namespace  User;

public class UserExamples: IMultipleExamplesProvider<User>
{
    public IEnumerable<SwaggerExample<User>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "test",
            new User()
            {
                ID = null,
                username = "amir_ah",
                password = "passWord",
                email = "example@gmail.com"
            }
        );
    }
}
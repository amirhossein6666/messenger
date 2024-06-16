using messenger.PV;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace messenger.User;
[Route("[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    [SwaggerRequestExample(typeof(User), typeof(UserExamples))]
    public async Task<User> Create(User user)
    {
        return await _userService.Create(user);
    }

    [HttpGet]
    public async Task<List<User>> FindAll()
    {
        return await _userService.FindAll();
    }

    [HttpGet("ID")]
    public async Task<User> FindOne(int ID)
    {
        return await _userService.FindOne(ID);
    }

    [HttpPatch]
    public async Task<User> Update(User user)
    {
        return await _userService.Update(user);
    }
}
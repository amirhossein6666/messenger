using System.IdentityModel.Tokens.Jwt;
using messenger.PV;
using Microsoft.AspNetCore.Authorization;
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
    [Route("SignUP")]
    [SwaggerRequestExample(typeof(User), typeof(UserExamples))]
    public async Task<User> SignUp(User user)
    {
        return await _userService.Create(user);
    }

    [HttpGet]
    [Authorize]
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

    [HttpGet]
    [Route("login")]
    public async Task<string> Login(string username, string password)
    {
        return await _userService.Login(username, password);
    }
}
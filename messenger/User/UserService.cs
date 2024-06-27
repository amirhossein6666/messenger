using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using messenger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OneOf;

namespace User;

public class UserService
{
    private readonly AppDbContext _appDbContext;
    private readonly IConfiguration _config;

    public UserService(AppDbContext appDbContext, IConfiguration config)
    {
        _appDbContext = appDbContext;
        _config = config;
    }

    public async Task<User> Create(User user)
    {
        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> FindAll()
    {
        return await _appDbContext.Users.ToListAsync();
    }

    public async Task<User> FindOne(int ID)
    {
        return await _appDbContext.Users.FindAsync(ID);
    }

    public async Task<User> Update(User updateUser)
    {
        _appDbContext.Users.Update(updateUser);
        await _appDbContext.SaveChangesAsync();
        return updateUser;
    }

    public async Task<string> Login(string username, string password)
    {
        var user = _appDbContext.Users.FromSqlInterpolated($"SELECT * FROM [User] WHERE Username = {username}")
            .AsEnumerable().FirstOrDefault();
        if (user != null)
        {
            if (user.password == password)
            {
                string token = GenerateToken(username);
                return token;
            }

            return "username and password doesnt match";
        }

        return "user not found";
    }

    private string GenerateToken(string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
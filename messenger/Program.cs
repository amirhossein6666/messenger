using AccountPV;
using ChannelMessage;
using GroupMessage;
using  PV;
using PVAccountMessage;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Account;
using AccountChannel;
using AccountContact;
using AccountGroup;
using Channel;
using ChannelAccountMessage;
using Group;
using GroupAccountMessage;
using Message;
using messenger;
using Notification;
using User;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.ExampleFilters()
);
//
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
//

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ChannelService>();
builder.Services.AddScoped<AccountChannelService>();
builder.Services.AddScoped<AccountContactService>();
builder.Services.AddScoped<AccountGroupService>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<AccountPVService>();
builder.Services.AddScoped<PVService>();
builder.Services.AddScoped<ChannelAccountMessageService>();
builder.Services.AddScoped<ChannelMessageService>();
builder.Services.AddScoped<GroupAccountMessageService>();
builder.Services.AddScoped<GroupMessageService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<PVAccountMessageService>();
builder.Services.AddScoped<UserService>();
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

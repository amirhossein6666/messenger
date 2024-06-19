using messenger.Account;
using messenger.AccountChannel;
using messenger.AccountContact;
using messenger.AccountGroup;
using messenger.AccountPV;
using messenger.Channel;
using messenger.ChannelAccountMessage;
using messenger.ChannelMessage;
using messenger.Group;
using messenger.GroupAccountMessage;
using messenger.GroupMessage;
using messenger.Message;
using messenger.MessageReply;
using messenger.Notification;
using messenger.PV;
using messenger.PVAccountMessage;
using messenger.User;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
builder.Services.AddScoped<MessageReplyService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<PVAccountMessageService>();
builder.Services.AddScoped<UserService>();
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<ChannelDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AccountChannleDbContext>();
builder.Services.AddDbContext<AccountContactDbContext>();
builder.Services.AddDbContext<AccountGroupDbContext>();
builder.Services.AddDbContext<GroupDbContext>();
builder.Services.AddDbContext<MessageDbContext>();
builder.Services.AddDbContext<AccountPVDbContext>();
builder.Services.AddDbContext<PVDbContext>();
builder.Services.AddDbContext<ChannelAccountMessageDbContext>();
builder.Services.AddDbContext<ChannelMessageDbContext>();
builder.Services.AddDbContext<GroupAccountMessageDbContext>();
builder.Services.AddDbContext<GroupMessageDbContext>();
builder.Services.AddDbContext<MessageReplyDbContext>();
builder.Services.AddDbContext<NotificationDbContext>();
builder.Services.AddDbContext<PVAccountMessageDbContext>();
builder.Services.AddDbContext<UserDbContext>();
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

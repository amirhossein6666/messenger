using messenger.Account;
using messenger.AccountChannel;
using messenger.AccountContact;
using messenger.AccountGroup;
using messenger.Channel;
using messenger.Group;
using messenger.Message;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ChannelService>();
builder.Services.AddScoped<AccountChannelService>();
builder.Services.AddScoped<AccountContactService>();
builder.Services.AddScoped<AccountGroupService>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<MessageService>();
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<ChannelDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AccountChannleDbContext>();
builder.Services.AddDbContext<AccountContactDbContext>();
builder.Services.AddDbContext<AccountGroupDbContext>();
builder.Services.AddDbContext<GroupDbContext>();
builder.Services.AddDbContext<MessageDbContext>();
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

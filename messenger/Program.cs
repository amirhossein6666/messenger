using messenger.Account;
using messenger.AccountChannel;
using messenger.AccountContact;
using messenger.Channel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ChannelService>();
builder.Services.AddScoped<AccountChannelService>();
builder.Services.AddScoped<AccountContactService>();
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<ChannelDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AccountChannleDbContext>();
builder.Services.AddDbContext<AccountContactDbContext>();
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

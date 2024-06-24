using Microsoft.EntityFrameworkCore;

namespace  Account
{
    public class AccountDbContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public AccountDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<Account> Account { get; set; }

    }
}
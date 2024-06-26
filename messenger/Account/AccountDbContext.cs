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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountContacts)
                .WithOne(ac => ac.Account)
                .HasForeignKey(ac => ac.AccountID);

        }

        public DbSet<Account> Account { get; set; }

    }
}
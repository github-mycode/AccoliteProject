using AccoliteBank.Models.Accounts;
using AccoliteBank.Models.Transactions;
using AccoliteBank.Models.Users;
using Microsoft.EntityFrameworkCore;
namespace AccoliteBank.Db
{
    public class BankDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public BankDbContext(IConfiguration configuration)
        {

            Configuration = configuration;

        }
        protected override void OnConfiguring
          (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BankDb");
        }
        public DbSet<UserModel> UserProfiles { get; set; }
        public DbSet<AccountModel> AccountDetail { get; set; }
        public DbSet<TransactionModel> TransactionDetail { get; set; }

    }
}

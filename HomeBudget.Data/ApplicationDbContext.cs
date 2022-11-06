using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PlaceEntity> Places { get; set; }
        public DbSet<TransactionEntry> Transactions { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ProviderEntity> Providers { get; set; }
        public DbSet<StateEntity> States { get; set; }
    }
}
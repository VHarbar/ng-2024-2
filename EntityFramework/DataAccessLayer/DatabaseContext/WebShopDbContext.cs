using DataAccessLayer.Configurations;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DatabaseContext
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

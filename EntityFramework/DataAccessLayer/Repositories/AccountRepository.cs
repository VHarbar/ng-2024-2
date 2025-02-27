using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;

namespace DataAccessLayer.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(WebShopDbContext ctx) : base(ctx)
        {
        }
    }
}

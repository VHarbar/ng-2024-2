using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly WebShopDbContext _ctx;
        public AccountRepository(WebShopDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Account> GetAccountByIdWithUserAsync(Guid id)
        {
            var account = _ctx.Set<Account>().Include(x => x.User).First(x => x.Id.Equals(id));
            return account;
        }
    }
}

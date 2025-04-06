using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _ctx;
        public AccountRepository(ApplicationDbContext ctx) : base(ctx)
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

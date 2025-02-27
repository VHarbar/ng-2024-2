using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WebShopDbContext ctx) : base(ctx)
        {
        }
    }
}

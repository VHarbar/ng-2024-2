using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccountByIdWithUserAsync(Guid id);
    }
}

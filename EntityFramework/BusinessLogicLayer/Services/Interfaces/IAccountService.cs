using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountModel> GetByIdAsync(Guid id);
    }
}

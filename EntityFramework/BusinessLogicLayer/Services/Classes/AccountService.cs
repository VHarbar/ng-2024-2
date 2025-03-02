using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interface;

namespace BusinessLogicLayer.Services.Classes
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountModel> GetByIdAsync(Guid id)
        {
            var account = await _accountRepository.GetAccountByIdWithUserAsync(id);
            return _mapper.Map<AccountModel>(account);
        }
    }
}

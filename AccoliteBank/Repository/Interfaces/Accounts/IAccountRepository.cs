using AccoliteBank.Dtos.Request.Account;
using AccoliteBank.Models.Accounts;

namespace AccoliteBank.Repository.Interfaces.Account
{
    public interface IAccountRepository
    {
        public Task<string> CreateAccount(AccountModel createAccountDto);
        public Task<string> UpdateAccount(AccountModel createAccountDto);
        public Task<bool> DeleteAccount(long  accountId);
        public Task<List<AccountModel>> GetAllAccount(long userId);
        public Task<AccountModel> GetAccountDetail(long? accountId);
    }
}

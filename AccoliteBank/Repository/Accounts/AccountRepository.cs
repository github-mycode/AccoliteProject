using AccoliteBank.Db;
using AccoliteBank.Dtos.Request.Account;
using AccoliteBank.Dtos.Response.User;
using AccoliteBank.Models.Accounts;
using AccoliteBank.Models.Transactions;
using AccoliteBank.Repository.Interfaces.Account;
using Microsoft.EntityFrameworkCore;

namespace AccoliteBank.Repository.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankDbContext _bankDbContext;
        public AccountRepository(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<string> CreateAccount(AccountModel createAccountDto)
        {
            try
            {
               
                var num = new Random();
                createAccountDto.AccountId = num.Next(1,100000);
                createAccountDto.IsActive = true;
                createAccountDto.CreatedAt = DateTime.Now;
                await _bankDbContext.AccountDetail.AddAsync(createAccountDto);
                await _bankDbContext.SaveChangesAsync();

                TransactionModel transactionDto = new();
                var Trannum = new Random();
                var ran_num = Trannum.Next(1, 100000);
                transactionDto.TransactionId = ran_num;
                transactionDto.CreationTime = DateTime.Now.Date;
                transactionDto.TransactionTime = DateTime.Now.Date;
                transactionDto.Amount = createAccountDto.AvailableBalance;
                transactionDto.AccountType = createAccountDto.AccountType;
                transactionDto.DepositType = Enum.DepositType.Deposit;
                transactionDto.Status = Enum.TransactionStatusTypeId.Success;
                transactionDto.AccountId = createAccountDto.AccountId;
                await _bankDbContext.TransactionDetail.AddAsync(transactionDto);
                await _bankDbContext.SaveChangesAsync();
                return $"Added is created successfully with account id {createAccountDto.AccountId}";

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAccount(long accountId)
        {
            try
            {
             var query = await  _bankDbContext.AccountDetail.Where(i => i.AccountId == accountId
                &&
                i.IsActive == true).FirstOrDefaultAsync();
                if(query != null)
                {
                    query.IsActive = false;
                    query.UpdatedAt = DateTime.Now;
                     _bankDbContext.AccountDetail.Update(query);
                    await _bankDbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }

        public async Task<List<AccountModel>> GetAllAccount(long userId)
        {
            try
            {
                var query = await _bankDbContext.AccountDetail.Where(i => i.UserId == userId && i.IsActive == true).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> UpdateAccount(AccountModel createAccountDto)
        {
            try
            {
                createAccountDto.UpdatedAt = DateTime.Now;
                 _bankDbContext.AccountDetail.
                    Update(createAccountDto);
                await _bankDbContext.SaveChangesAsync(true);
                return "Account Updated Successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<AccountModel> GetAccountDetail(long? accountId)
        {
            try
            {
                var query = await _bankDbContext.AccountDetail.Where(i => i.AccountId == accountId &&
                i.IsActive ==true ).FirstOrDefaultAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

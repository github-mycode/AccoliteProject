using AccoliteBank.Db;
using AccoliteBank.Dtos.Request.Transaction;
using AccoliteBank.Models.Accounts;
using AccoliteBank.Models.Transactions;
using AccoliteBank.Repository.Interfaces.Transaction;
using Microsoft.EntityFrameworkCore;

namespace AccoliteBank.Repository.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankDbContext _bankDbContext;
        public TransactionRepository(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<List<TransactionModel>> GetAllTransaction(long accountId)
        {
            try
            {
                var query = await _bankDbContext.TransactionDetail.Where(i => i.AccountId == accountId).ToListAsync();
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransactionModel> Transaction(TransactionModel transactionDto, AccountModel accountModel)
        {
            try
            {
                var num = new Random();
                var ran_num = num.Next(1,100000);
                transactionDto.TransactionId = ran_num;
                transactionDto.CreationTime = DateTime.Now;
                transactionDto.TransactionTime = DateTime.Now;
                transactionDto.Status = Enum.TransactionStatusTypeId.Success;
                await _bankDbContext.TransactionDetail.AddAsync(transactionDto);
                _bankDbContext.AccountDetail.Update(accountModel);
                await _bankDbContext.SaveChangesAsync();

                return transactionDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

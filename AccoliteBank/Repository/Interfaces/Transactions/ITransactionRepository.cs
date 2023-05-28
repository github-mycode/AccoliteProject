using AccoliteBank.Dtos.Request.Transaction;
using AccoliteBank.Models.Accounts;
using AccoliteBank.Models.Transactions;

namespace AccoliteBank.Repository.Interfaces.Transaction
{
    public interface ITransactionRepository
    {
        public Task<TransactionModel> Transaction(TransactionModel transactionDto, AccountModel accountModel);
        public Task<List<TransactionModel>> GetAllTransaction(long accountId);
    }
}

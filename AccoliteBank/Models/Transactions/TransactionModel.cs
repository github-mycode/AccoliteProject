using AccoliteBank.Enum;
using AccoliteBank.Models.Accounts;

namespace AccoliteBank.Models.Transactions
{
    public class TransactionModel
    {
        public Guid? Id { get; set; }
        public long? TransactionId { get; set; }
        public DateTime? TransactionTime { get; set; }
        public AccountType? AccountType { get; set; }
        public double? Amount { get; set; }
        public TransactionStatusTypeId? Status { get; set; }
        public DepositType? DepositType { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? AccountId {  get; set; }
        public AccountModel? Accounts { get; set; }

    }
}

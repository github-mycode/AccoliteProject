using AccoliteBank.Enum;

namespace AccoliteBank.Dtos.Request.Transaction;
public class TransactionDto
{
    internal Guid? Id { get; set; }
    internal long? TransactionId { get; set; }
    internal DateTime? TransactionTime { get; set; }
    public AccountType? AccountType { get; set; }
    public double? Amount { get; set; }
    internal TransactionStatusTypeId? Status { get; set; }
    public DepositType? DepositType { get; set; }
    internal DateTime? CreationTime { get; set; }
    public long? AccountId { get; set; }

}

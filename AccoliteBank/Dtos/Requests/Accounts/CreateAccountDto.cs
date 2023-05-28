using AccoliteBank.Enum;

namespace AccoliteBank.Dtos.Request.Account;
public class CreateAccountDto
{
    internal Guid? Id { get; set; }
    internal long? AccountId { get; set; }
    public double? AvailableBalance { get; set; }
    public AccountType? AccountType { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long UserId { get; set; }

}

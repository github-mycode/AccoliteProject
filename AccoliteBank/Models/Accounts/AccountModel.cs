using AccoliteBank.Enum;
using AccoliteBank.Models.Transactions;
using AccoliteBank.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace AccoliteBank.Models.Accounts
{
    public class AccountModel
    {
        public Guid? Id { get; set; }
        public long? AccountId { get; set; }
        [Required]
        [Range(1000.0, Double.MaxValue, ErrorMessage = "Minimum $100  Required for Account Opening")]
        public double? AvailableBalance { get; set; }
        public AccountType? AccountType { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<TransactionModel>? Transactions { get; set; }
        public long UserId { get; set; }
        public UserModel? User { get; set; }

    }
}

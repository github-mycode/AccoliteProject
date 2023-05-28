using AccoliteBank.Enum;
using AccoliteBank.Models.Accounts;
using System.ComponentModel.DataAnnotations;

namespace AccoliteBank.Models.Users
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
        public List<AccountModel>? Accounts { get; set; }
    }
}

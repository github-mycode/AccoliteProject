using AccoliteBank.Enum;
using System.ComponentModel.DataAnnotations;

namespace AccoliteBank.Dtos.Request.User;
public class RegisterDto
{
    internal Guid? Id { get; set; }
    internal long? UserId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [Phone]
    public string? ContactNumber { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public Gender Gender { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    internal DateTime Created { get; set; }

}

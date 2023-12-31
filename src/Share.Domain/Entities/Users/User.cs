using System.ComponentModel.DataAnnotations;
using Share.Domain.Commons;
using Share.Domain.Enums;

namespace Share.Domain.Entities.Users;

public class User:Auditable
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [EmailAddress][Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
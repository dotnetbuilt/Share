using System.ComponentModel.DataAnnotations;
using Share.Domain.Enums;

namespace Share.Service.DTOs.Users;

public class UserCreationDto
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [EmailAddress][Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public Role Role { get; set; }
}
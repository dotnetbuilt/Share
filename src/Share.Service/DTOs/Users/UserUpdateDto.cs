using Share.Domain.Enums;

namespace Share.Service.DTOs.Users;

public class UserUpdateDto
{
    public long Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
using Share.Domain.Enums;

namespace Share.Service.DTOs.Users;

public class UserResultDto
{
    public long Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}
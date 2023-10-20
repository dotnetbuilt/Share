using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.Follows;

public class FollowResultDto
{
    public long Id { get; set; }
    public UserResultDto Following { get; set; }
    public UserResultDto Follower { get; set; }
}
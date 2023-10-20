using Share.Domain.Commons;
using Share.Domain.Entities.Users;

namespace Share.Domain.Entities.Follows;

public class Follow:BaseEntity
{
    public long FollowingId { get; set; }
    public User Following { get; set; }

    public long FollowerId { get; set; }
    public User Follower { get; set; }
}
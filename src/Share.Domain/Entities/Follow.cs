using Share.Domain.Commons;

namespace Share.Domain.Entities;

public class Follow:BaseEntity
{
    public long FollowingId { get; set; }
    public User Following { get; set; }

    public long FollowerId { get; set; }
    public User Follower { get; set; }
}
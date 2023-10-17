using Share.Domain.Commons;

namespace Share.Domain.Entities;

public class LikedStory:BaseEntity
{
    public long StoryId { get; set; }
    public Story Story { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
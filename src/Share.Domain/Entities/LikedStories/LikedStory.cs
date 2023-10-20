using Share.Domain.Commons;
using Share.Domain.Entities.Stories;
using Share.Domain.Entities.Users;

namespace Share.Domain.Entities.LikedStories;

public class LikedStory:BaseEntity
{
    public long StoryId { get; set; }
    public Story Story { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
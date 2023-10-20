using Share.Domain.Commons;
using Share.Domain.Entities.Comments;
using Share.Domain.Entities.Stories;
using Share.Domain.Entities.Users;

namespace Share.Domain.Entities.Replies;

public class Reply:Auditable
{
    public string Text { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long StoryId { get; set; }
    public Story Story { get; set; }

    public long CommentId { get; set; }
    public Comment Comment { get; set; }
}
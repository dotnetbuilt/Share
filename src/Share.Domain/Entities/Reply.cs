using Share.Domain.Commons;

namespace Share.Domain.Entities;

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
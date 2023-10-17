using Share.Domain.Commons;

namespace Share.Domain.Entities;

public class UserProfileImage:BaseEntity
{
    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
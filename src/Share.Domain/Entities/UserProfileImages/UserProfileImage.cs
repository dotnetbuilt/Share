using Share.Domain.Commons;
using Share.Domain.Entities.Attachments;
using Share.Domain.Entities.Users;

namespace Share.Domain.Entities.UserProfileImages;

public class UserProfileImage:BaseEntity
{
    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
using Share.Domain.Commons;

namespace Share.Domain.Entities;

public class StoryImage:BaseEntity
{
    public long StoryId { get; set; }
    public Story Story { get; set; }

    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}
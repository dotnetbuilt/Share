using Share.Domain.Commons;
using Share.Domain.Entities.Attachments;
using Share.Domain.Entities.Stories;

namespace Share.Domain.Entities.StoryImages;

public class StoryImage:BaseEntity
{
    public long StoryId { get; set; }
    public Story Story { get; set; }

    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}
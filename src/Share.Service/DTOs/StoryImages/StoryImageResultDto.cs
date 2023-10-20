using Share.Service.DTOs.Attachments;
using Share.Service.DTOs.Stories;

namespace Share.Service.DTOs.StoryImages;

public class StoryImageResultDto
{
    public long Id { get; set; }
    public StoryResultDto Story { get; set; }
    public AttachmentResultDto Attachment { get; set; }
}
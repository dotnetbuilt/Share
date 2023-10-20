using Share.Domain.Entities;
using Share.Service.DTOs.Stories;

namespace Share.Service.DTOs.StoryImages;

public class StoryImageResultDto
{
    public long Id { get; set; }
    public StoryResultDto StoryStory { get; set; }
    public Attachment Attachment { get; set; }
}
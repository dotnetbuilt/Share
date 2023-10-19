using Share.Domain.Entities;
using Share.Service.DTOs.Stories;

namespace Share.Service.DTOs.StoryImages;

public class StoryImageResultDto
{
    public long Id { get; set; }
    public StoryResultDto StoryResultDto { get; set; }
    public Attachment StoryImage { get; set; }
}
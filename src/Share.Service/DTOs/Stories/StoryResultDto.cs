using Share.Service.DTOs.StoryImages;
using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.Stories;

public class StoryResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public UserResultDto User { get; set; }
    public int Likes { get; set; }
    public int Comments { get; set; }
    public int Saved { get; set; }
    public ICollection<StoryImageResultDto> StoryImages { get; set; }
}
using Share.Service.DTOs.Stories;
using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.SavedStories;

public class SavedStoryResultDto
{
    public long Id { get; set; }
    public StoryResultDto Story { get; set; }
    public UserResultDto User { get; set; }
}
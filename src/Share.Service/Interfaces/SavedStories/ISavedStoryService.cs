using Share.Service.DTOs.SavedStories;
using Share.Service.DTOs.Stories;
using Share.Service.DTOs.Users;

namespace Share.Service.Interfaces.SavedStories;

public interface ISavedStoryService
{
    ValueTask<SavedStoryResultDto> AddAsync(SavedStoryCreationDto dto);
    ValueTask<bool> RemoveAsync(long savedStoryId);
    ValueTask<IEnumerable<UserResultDto>> RetrieveUsersByStoryIdAsync(long storyId);
    ValueTask<IEnumerable<StoryResultDto>> RetrieveStoriesByUserIdAsync(long userId);
    ValueTask<long> RetrieveNumberOfUsersByStoryIdAsync(long storyId);
}
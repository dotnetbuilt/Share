using Share.Service.DTOs.LikedStories;

namespace Share.Service.Interfaces.LikedStories;

public interface ILikedStoryService
{
    ValueTask<LikedStoryResultDto> AddAsync(LikedStoryCreationDto dto);
    ValueTask<bool> RemoveAsync(long likedStoryId);
    ValueTask<IEnumerable<LikedStoryResultDto>> RetrieveAllByUserIdAsync(long userId);
    ValueTask<IEnumerable<LikedStoryResultDto>> RetrieveAllByStoryIdAsync(long storyId);
    ValueTask<long> RetrieveNumberOfLikesByStoryIdAsync(long storyId);
    ValueTask<bool> DestroyAsync(long likedStoryId);
}
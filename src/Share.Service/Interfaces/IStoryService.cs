using Share.Service.DTOs.Stories;

namespace Share.Service.Interfaces;

public interface IStoryService
{
    ValueTask<StoryResultDto> AddAsync(StoryCreationDto dto);
    ValueTask<StoryResultDto> ModifyAsync(StoryUpdateDto dto);
    ValueTask<bool> RemoveAsync(long storyId);
    ValueTask<StoryResultDto> RetrieveByIdAsync(long storyId);
    ValueTask<IEnumerable<StoryResultDto>> RetrieveAllByUserIdAsync(long userId);
}
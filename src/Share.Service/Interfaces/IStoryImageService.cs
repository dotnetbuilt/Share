using Share.Service.DTOs.StoryImages;

namespace Share.Service.Interfaces;

public interface IStoryImageService
{
    ValueTask<StoryImageResultDto> AddAsync(StoryImageCreationDto dto);
    ValueTask<StoryImageResultDto> RetrieveByIdAsync(long storyImageId);
    ValueTask<bool> RemoveAsync(long storyImageId);
}
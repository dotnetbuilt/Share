using Microsoft.AspNetCore.Http;
using Share.Service.DTOs.StoryImages;

namespace Share.Service.Interfaces.StoryImages;

public interface IStoryImageService
{
    ValueTask<StoryImageResultDto> AddAsync(long storyId,IFormFile image);
    ValueTask<StoryImageResultDto> RetrieveByIdAsync(long storyImageId);
    ValueTask<bool> RemoveAsync(long storyImageId);
}
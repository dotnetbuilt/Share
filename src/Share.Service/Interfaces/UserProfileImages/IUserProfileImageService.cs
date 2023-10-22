using Microsoft.AspNetCore.Http;
using Share.Service.DTOs.UserProfileImages;

namespace Share.Service.Interfaces.UserProfileImages;

public interface IUserProfileImageService
{
    ValueTask<UserProfileImageResultDto> AddAsync(long userId, IFormFile image);
    ValueTask<UserProfileImageResultDto> RetrieveByIdAsync(long imageId);
    ValueTask<bool> RemoveAsync(long imageId);
}
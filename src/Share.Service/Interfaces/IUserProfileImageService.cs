using Share.Service.DTOs.UserProfileImages;

namespace Share.Service.Interfaces;

public interface IUserProfileImageService
{
    ValueTask<UserProfileImageResultDto> AddAsync(UserProfileImageCreationDto dto);
    ValueTask<UserProfileImageResultDto> RetrieveByIdAsync(long imageId);
    ValueTask<bool> RemoveAsync(long imageId);
}
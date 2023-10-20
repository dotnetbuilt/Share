using Share.Service.DTOs.Users;

namespace Share.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserResultDto> AddAsync(UserCreationDto dto);
    ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto);
    ValueTask<bool> RemoveAsync(long userId);
    ValueTask<UserResultDto> RetrieveByIdAsync(long userId);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync();
    ValueTask<long> RetrieveNumberOfUsers();
}
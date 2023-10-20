using Share.Service.DTOs.Follows;
using Share.Service.DTOs.Users;

namespace Share.Service.Interfaces;

public interface IFollowService
{
    ValueTask<bool> AddAsync(FollowCreationDto dto);
    ValueTask<bool> RemoveAsync(long followId);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAllFollowingsByFollowerIdAsync(long followerId);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAllFollowersByFollowingIdAsync(long followingId);
    ValueTask<long> RetrieveNumberOfFollowersAsync(long followingId);
    ValueTask<long> RetrieveNumberOfFollowingsAsync(long followerId);
}
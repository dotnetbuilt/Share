using Share.Service.DTOs.Follows;

namespace Share.Service.Interfaces;

public interface IFollowService
{
    ValueTask<bool> AddAsync(FollowCreationDto dto);
    ValueTask<bool> RemoveAsync(long followId);
    ValueTask<IEnumerable<FollowResultDto>> RetrieveAllFollowingsByFollowerIdAsync(long followerId);
    ValueTask<IEnumerable<FollowResultDto>> RetrieveAllFollowersByFollowingIdAsync(long followingId);
    ValueTask<long> RetrieveNumberOfFollowersAsync(long followingId);
    ValueTask<long> RetrieveNumberOfFollowingsAsync(long followerId);
}
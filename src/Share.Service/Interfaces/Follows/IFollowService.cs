using Share.Service.DTOs.Follows;

namespace Share.Service.Interfaces.Follows;

public interface IFollowService
{
    ValueTask<FollowResultDto> AddAsync(FollowCreationDto dto);
    ValueTask<bool> RemoveAsync(long followId);
    ValueTask<IEnumerable<FollowResultDto>> RetrieveAllFollowingsByFollowerIdAsync(long followerId);
    ValueTask<IEnumerable<FollowResultDto>> RetrieveAllFollowersByFollowingIdAsync(long followingId);
    ValueTask<long> RetrieveNumberOfFollowersAsync(long followingId);
    ValueTask<long> RetrieveNumberOfFollowingsAsync(long followerId);
    ValueTask<bool> DestroyAsync(long followId);
}
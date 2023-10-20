using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.Follows;
using Share.Service.DTOs.Follows;
using Share.Service.Exceptions;
using Share.Service.Interfaces;

namespace Share.Service.Services;

public class FollowService:IFollowService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public FollowService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<bool> AddAsync(FollowCreationDto dto)
    {
        var existFollow = await _unitOfWork.FollowRepository.SelectAsync(expression: follow =>
            follow.FollowerId == dto.FollowerId &&
            follow.FollowingId == dto.FollowingId);

        if (existFollow != null)
            throw new AlreadyExistsException(message: "Follow is already exist");

        var existFollower =
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.FollowerId) ??
            throw new NotFoundException(message: "Follower(User) is not found");

        var existFollowing =
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.FollowingId) ??
            throw new NotFoundException(message: "Following(User) is not found");

        var mappedFollow = _mapper.Map<Follow>(source: dto);
        mappedFollow.FollowerId = existFollower.Id;
        mappedFollow.Follower = existFollower;
        mappedFollow.FollowingId = existFollowing.Id;
        mappedFollow.Following = existFollowing;

        await _unitOfWork.FollowRepository.CreateAsync(entity: mappedFollow);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> RemoveAsync(long followId)
    {
        var existFollow =
            await _unitOfWork.FollowRepository.SelectAsync(expression: follow => follow.Id == followId) ??
            throw new NotFoundException(message: "Follow is not found");
        
        _unitOfWork.FollowRepository.Delete(entity:existFollow);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<FollowResultDto>> RetrieveAllFollowingsByFollowerIdAsync(long followerId)
    {
        var followings = await _unitOfWork.FollowRepository
            .SelectAll(expression: follow => follow.FollowerId == followerId, 
                        includes:new[] { "Following" , "Follower"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<FollowResultDto>>(source: followings);
    }

    public async ValueTask<IEnumerable<FollowResultDto>> RetrieveAllFollowersByFollowingIdAsync(long followingId)
    {
        var followers = await _unitOfWork.FollowRepository
            .SelectAll(expression: follow => follow.FollowingId == followingId, 
                includes:new[] { "Following" , "Follower"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<FollowResultDto>>(source: followers);
    }

    public async ValueTask<long> RetrieveNumberOfFollowersAsync(long followingId)
        => await _unitOfWork.FollowRepository
            .SelectAll(expression: follow => follow.FollowingId == followingId)
            .LongCountAsync();

    public async ValueTask<long> RetrieveNumberOfFollowingsAsync(long followerId)
        => await _unitOfWork.FollowRepository
            .SelectAll(expression: follow => follow.FollowerId == followerId)
            .LongCountAsync();
}
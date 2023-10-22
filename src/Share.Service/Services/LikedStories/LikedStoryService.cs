using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.LikedStories;
using Share.Service.DTOs.LikedStories;
using Share.Service.Exceptions;
using Share.Service.Interfaces.LikedStories;

namespace Share.Service.Services.LikedStories;

public class LikedStoryService:ILikedStoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LikedStoryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<LikedStoryResultDto> AddAsync(LikedStoryCreationDto dto)
    {
        var existLikedStory = await _unitOfWork.LikedStoryRepository.SelectAsync(expression: likedStory =>
            likedStory.StoryId == dto.StoryId && likedStory.UserId == dto.UserId);

        if (existLikedStory != null)
            throw new AlreadyExistsException(message: "Story is already liked");

        var existUser = 
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.UserId)
                        ?? throw new NotFoundException(message: "User is not found");

        var existStory = 
            await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Id == dto.StoryId,
                includes:new[]{"User"})
                         ?? throw new NotFoundException(message: "Story is not found");

        var mappedLikedStory = _mapper.Map<LikedStory>(source: dto);
        mappedLikedStory.StoryId = existStory.Id;
        mappedLikedStory.Story = existStory;
        mappedLikedStory.UserId = existUser.Id;
        mappedLikedStory.User = existUser;

        await _unitOfWork.LikedStoryRepository.CreateAsync(entity: mappedLikedStory);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<LikedStoryResultDto>(source: mappedLikedStory);
    }

    public async ValueTask<bool> RemoveAsync(long likedStoryId)
    {
        var existLikedStory = await _unitOfWork.LikedStoryRepository
                                  .SelectAsync(expression: likedStory => likedStory.Id == likedStoryId)
                              ?? throw new NotFoundException(message: "Story is not liked");
        
        _unitOfWork.LikedStoryRepository.Delete(entity:existLikedStory);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<LikedStoryResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var likedStories = await _unitOfWork.LikedStoryRepository
            .SelectAll(expression: likedStory => likedStory.UserId == userId,
                includes:new[]{"User","Story.User"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<LikedStoryResultDto>>(source: likedStories);
    }

    public async ValueTask<IEnumerable<LikedStoryResultDto>> RetrieveAllByStoryIdAsync(long storyId)
    {
        var likedStories = await _unitOfWork.LikedStoryRepository
            .SelectAll(expression: likedStory => likedStory.StoryId == storyId,
                includes:new[]{"User","Story.User"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<LikedStoryResultDto>>(source: likedStories);
    }

    public async ValueTask<long> RetrieveNumberOfLikesByStoryIdAsync(long storyId)
        => await _unitOfWork.LikedStoryRepository
            .SelectAll(expression: likedStory => likedStory.StoryId == storyId)
            .LongCountAsync();

    public async ValueTask<bool> DestroyAsync(long likedStoryId)
    {
        var likedStory = await _unitOfWork.LikedStoryRepository
                             .SelectAsync(expression: likedStory => likedStory.Id == likedStoryId) ??
                         throw new NotFoundException(message: "Liked Story is not found");
        
        _unitOfWork.LikedStoryRepository.Destroy(entity:likedStory);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
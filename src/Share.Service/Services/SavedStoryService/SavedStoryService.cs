using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.SavedStories;
using Share.Service.DTOs.SavedStories;
using Share.Service.Exceptions;
using Share.Service.Interfaces.SavedStories;

namespace Share.Service.Services.SavedStoryService;

public class SavedStoryService:ISavedStoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SavedStoryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<SavedStoryResultDto> AddAsync(SavedStoryCreationDto dto)
    {
        var existSavedStory = await _unitOfWork.SavedStoryRepository
            .SelectAsync(expression: savedStory => savedStory.StoryId == dto.StoryId &&
                                                   savedStory.UserId == dto.UserId);
        
        if(existSavedStory != null)    
            throw new AlreadyExistsException(message: "Story is already saved");

        var existUser = await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.UserId)
                        ?? throw new NotFoundException(message: "User is not found");

        var existStory = await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Id == dto.StoryId,
                             includes:new[]{"User"})
                         ?? throw new NotFoundException(message: "Story is not found");

        var mappedStory = _mapper.Map<SavedStory>(source: dto);
        mappedStory.StoryId = existStory.Id;
        mappedStory.Story = existStory;
        mappedStory.UserId = existUser.Id;
        mappedStory.User = existUser;

        await _unitOfWork.SavedStoryRepository.CreateAsync(entity: mappedStory);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<SavedStoryResultDto>(source: mappedStory);
    }

    public async ValueTask<bool> RemoveAsync(long savedStoryId)
    {
        var existSavedStory = await _unitOfWork.SavedStoryRepository
                                  .SelectAsync(expression: story => story.Id == savedStoryId)
                              ?? throw new NotFoundException(message: "SavedStory is not found");
        
        _unitOfWork.SavedStoryRepository.Delete(entity:existSavedStory);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<SavedStoryResultDto>> RetrieveUsersByStoryIdAsync(long storyId)
    {
        var savedStories = await _unitOfWork.SavedStoryRepository
            .SelectAll(expression: savedStory => savedStory.StoryId == storyId,
                includes:new[]{"User","Story.User"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<SavedStoryResultDto>>(source: savedStories);
    }

    public async ValueTask<IEnumerable<SavedStoryResultDto>> RetrieveStoriesByUserIdAsync(long userId)
    {
        var savedStories = await _unitOfWork.SavedStoryRepository
            .SelectAll(expression: savedStory => savedStory.UserId == userId,
                includes:new[]{"User","Story.User"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<SavedStoryResultDto>>(source: savedStories);
    }

    public async ValueTask<long> RetrieveNumberOfUsersByStoryIdAsync(long storyId)
        => await _unitOfWork.SavedStoryRepository
            .SelectAll(expression: savedStory => savedStory.StoryId == storyId)
            .LongCountAsync();
}
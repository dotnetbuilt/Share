using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contracts;
using Share.Domain.Entities;
using Share.Service.DTOs.Stories;
using Share.Service.Exceptions;
using Share.Service.Interfaces;

namespace Share.Service.Services;

public class StoryService:IStoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public StoryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<StoryResultDto> AddAsync(StoryCreationDto dto)
    {
        var existUser = 
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.UserId)
            ?? throw new NotFoundException(message:"User is not found!");

        var existStory = 
            await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Title == dto.Title);

        if (existStory != null)
            throw new AlreadyExistsException(message: "Story title is already used");

        var mappedStory = _mapper.Map<Story>(source: dto);
        mappedStory.UserId = existUser.Id;
        mappedStory.User = existUser;

        await _unitOfWork.StoryRepository.CreateAsync(entity: mappedStory);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<StoryResultDto>(source: mappedStory);
    }

    public async ValueTask<StoryResultDto> ModifyAsync(StoryUpdateDto dto)
    {
        var existStory = await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Id == dto.Id)
                         ?? throw new NotFoundException(message: "Story is not found");

        var mappedStory = _mapper.Map(source: dto, destination: existStory);
        
        _unitOfWork.StoryRepository.Update(entity:mappedStory);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<StoryResultDto>(source: mappedStory);
    }

    public async ValueTask<bool> RemoveAsync(long storyId)
    {
        var existStory = await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Id == storyId)
                         ?? throw new NotFoundException(message: "Story is not found");
        
        _unitOfWork.StoryRepository.Delete(entity:existStory);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<StoryResultDto> RetrieveByIdAsync(long storyId)
    {
        var existStory = await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Id == storyId)
                         ?? throw new NotFoundException(message: "Story is not found");

        return _mapper.Map<StoryResultDto>(source: existStory);
    }

    public async ValueTask<IEnumerable<StoryResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var stories = await _unitOfWork.StoryRepository.
            SelectAll(expression: story => story.UserId == userId).ToListAsync();

        return _mapper.Map<IEnumerable<StoryResultDto>>(source: stories);
    }
}
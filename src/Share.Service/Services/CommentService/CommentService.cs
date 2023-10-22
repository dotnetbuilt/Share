using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.Comments;
using Share.Service.DTOs.Comments;
using Share.Service.Exceptions;
using Share.Service.Interfaces.Comments;

namespace Share.Service.Services.CommentService;

public class CommentService:ICommentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CommentService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<CommentResultDto> AddAsync(CommentCreationDto dto)
    {
        var existUser = 
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.UserId)
                        ?? throw new NotFoundException(message: "User is not found");

        var existStory = 
            await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Id == dto.StoryId,
                includes:new[]{"User"})
                         ?? throw new NotFoundException(message: "Story is not found");

        var mappedComment = _mapper.Map<Comment>(source: dto);
        mappedComment.UserId = existUser.Id;
        mappedComment.User = existUser;
        mappedComment.StoryId = existStory.Id;
        mappedComment.Story = existStory;

        await _unitOfWork.CommentRepository.CreateAsync(entity: mappedComment);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CommentResultDto>(source: mappedComment);
    }

    public async ValueTask<CommentResultDto> ModifyAsync(CommentUpdateDto dto)
    {
        var existComment =
            await _unitOfWork.CommentRepository.SelectAsync(expression: comment => comment.Id == dto.Id,
                includes:new[]{"User","Story.User"})
            ?? throw new NotFoundException(message: "Comment is not found");

        var mappedComment = _mapper.Map(source: dto, destination: existComment);
        
        _unitOfWork.CommentRepository.Update(entity:mappedComment);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CommentResultDto>(source: mappedComment);
    }

    public async ValueTask<IEnumerable<CommentResultDto>> RetrieveAllByStoryIdAsync(long storyId)
    {
        var comments = await _unitOfWork.CommentRepository
            .SelectAll(expression: comment => comment.StoryId == storyId,
                includes:new[]{"User","Story.User"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<CommentResultDto>>(source: comments);
    }

    public async ValueTask<IEnumerable<CommentResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var comments = await _unitOfWork.CommentRepository
            .SelectAll(expression: comment => comment.UserId == userId,
                includes:new[]{"User","Story.User"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<CommentResultDto>>(source: comments);
    }

    public async ValueTask<bool> DestroyAsync(long commentId)
    {
        var comment =
            await _unitOfWork.CommentRepository.SelectAsync(expression: comment => comment.Id == commentId) ??
            throw new NotFoundException(message: "Comment is not found");
        
        _unitOfWork.CommentRepository.Destroy(entity:comment);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
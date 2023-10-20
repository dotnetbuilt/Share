using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.Replies;
using Share.Service.DTOs.Replies;
using Share.Service.Exceptions;
using Share.Service.Interfaces.Replies;

namespace Share.Service.Services.Replies;

public class ReplyService:IReplyService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ReplyService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ReplyResultDto> AddAsync(ReplyCreationDto dto)
    {
        var existUser =
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.UserId) ??
            throw new NotFoundException(message: "User is not found");

        var existStory =
            await _unitOfWork.StoryRepository.SelectAsync(expression: story => story.Id == dto.StoryId,
            includes:new[]{"User"}) ??
            throw new NotFoundException(message: "Story is not found");

        var existComment = await _unitOfWork.CommentRepository
                               .SelectAsync(expression: comment => comment.Id == dto.CommentId,
                                   includes: new[] { "User", "Story.User" }) ??
                           throw new NotFoundException(message: "Comment is not found");

        var mappedReply = _mapper.Map<Reply>(source: dto);
        mappedReply.User = existUser;
        mappedReply.UserId = existComment.Id;
        mappedReply.Story = existStory;
        mappedReply.StoryId = existStory.Id;
        mappedReply.Comment = existComment;
        mappedReply.CommentId = existComment.Id;

        await _unitOfWork.ReplyRepository.CreateAsync(entity: mappedReply);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ReplyResultDto>(source: mappedReply);
    }

    public async ValueTask<ReplyResultDto> ModifyAsync(ReplyUpdateDto dto)
    {
        var existReply =
            await _unitOfWork.ReplyRepository.SelectAsync(expression: reply => reply.Id == dto.Id,
                includes:new[]{"User","Story.User","Comment.Story.User"}) ??
            throw new NotFoundException(message: "Reply is not found");

        var mappedReply = _mapper.Map(source: dto, destination: existReply);
        
        _unitOfWork.ReplyRepository.Update(entity:mappedReply);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ReplyResultDto>(source: mappedReply);
    }

    public async ValueTask<IEnumerable<ReplyResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var replies = await _unitOfWork.ReplyRepository
            .SelectAll(expression: reply => reply.UserId == userId,
                includes: new[] { "User", "Story.User", "Comment.Story.User" })
            .ToListAsync();

        return _mapper.Map<IEnumerable<ReplyResultDto>>(source: replies);
    }
}
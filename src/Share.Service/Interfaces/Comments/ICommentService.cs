using Share.Service.DTOs.Comments;

namespace Share.Service.Interfaces.Comments;

public interface ICommentService
{
    ValueTask<CommentResultDto> AddAsync(CommentCreationDto dto);
    ValueTask<CommentResultDto> ModifyAsync(CommentUpdateDto dto);
    ValueTask<IEnumerable<CommentResultDto>> RetrieveAllByStoryIdAsync(long storyId);
}
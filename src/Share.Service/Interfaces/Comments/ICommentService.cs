using Share.Service.DTOs.Comments;

namespace Share.Service.Interfaces.Comments;

public interface ICommentService
{
    ValueTask<CommentResultDto> AddAsync(CommentCreationDto dto);
    ValueTask<CommentResultDto> ModifyAsync(CommentUpdateDto dto);
    ValueTask<IEnumerable<CommentResultDto>> RetrieveAllByStoryIdAsync(long storyId);
    ValueTask<IEnumerable<CommentResultDto>> RetrieveAllByUserIdAsync(long userId);
    ValueTask<bool> DestroyAsync(long commentId);
}
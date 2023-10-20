using Share.Service.DTOs.Replies;

namespace Share.Service.Interfaces.Replies;

public interface IReplyService
{
    ValueTask<ReplyResultDto> AddAsync(ReplyCreationDto dto);
    ValueTask<ReplyResultDto> ModifyAsync(ReplyUpdateDto dto);
    ValueTask<IEnumerable<ReplyResultDto>> RetrieveAllByUserIdAsync(long userId);
}
using Share.Domain.Entities;
using Share.Service.DTOs.Replies;
using Share.Service.DTOs.Stories;
using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.Comments;

public class CommentResultDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public UserResultDto UserResultDto { get; set; }
    public StoryResultDto StoryResultDto { get; set; }
    public ICollection<ReplyResultDto> ReplyResultDtos { get; set; }
}
using Share.Service.DTOs.Comments;
using Share.Service.DTOs.Stories;
using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.Replies;

public class ReplyResultDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public UserResultDto UserResultDto { get; set; }
    public StoryResultDto StoryResultDto { get; set; }
    public CommentResultDto CommentResultDto { get; set; }
}
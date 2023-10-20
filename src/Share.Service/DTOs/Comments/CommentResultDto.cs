using Share.Service.DTOs.Replies;
using Share.Service.DTOs.Stories;
using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.Comments;

public class CommentResultDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public UserResultDto User { get; set; }
    public StoryResultDto Story { get; set; }
    public ICollection<ReplyResultDto> Replies { get; set; }
}
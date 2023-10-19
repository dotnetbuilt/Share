namespace Share.Service.DTOs.Replies;

public class ReplyUpdateDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public long UserId { get; set; }
    public long StoryId { get; set; }
    public long CommentId { get; set; }
}
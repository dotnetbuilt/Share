namespace Share.Service.DTOs.Comments;

public class CommentUpdateDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public long UserId { get; set; }
    public long StoryId { get; set; }
}
namespace Share.Service.DTOs.Comments;

public class CommentCreationDto
{
    public string Text { get; set; }
    public long UserId { get; set; }
    public long StoryId { get; set; }
}
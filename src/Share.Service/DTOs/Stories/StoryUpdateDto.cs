namespace Share.Service.DTOs.Stories;

public class StoryUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public long UserId { get; set; }
}
namespace Share.Service.DTOs.Stories;

public class StoryCreationDto
{
    public string Title { get; set; }
    public string Text { get; set; }
    public long UserId { get; set; }
}
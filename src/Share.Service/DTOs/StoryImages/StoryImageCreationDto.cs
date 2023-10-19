using Microsoft.AspNetCore.Http;

namespace Share.Service.DTOs.StoryImages;

public class StoryImageCreationDto
{
    public long StoryId { get; set; }
    public IFormFile StoryImage { get; set; }
}
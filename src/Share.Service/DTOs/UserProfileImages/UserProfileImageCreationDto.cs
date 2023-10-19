using Microsoft.AspNetCore.Http;

namespace Share.Service.DTOs.UserProfileImages;

public class UserProfileImageCreationDto
{
    public IFormFile ProfileImage { get; set; }
    public long UserId { get; set; }
}
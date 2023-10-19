using Share.Domain.Entities;
using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.UserProfileImages;

public class UserProfileImageResultDto
{
    public long Id { get; set; }
    public Attachment ProfileImage { get; set; }
    public UserResultDto UserResultDto { get; set; }
}
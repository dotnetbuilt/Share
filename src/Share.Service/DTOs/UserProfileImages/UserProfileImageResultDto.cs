using Share.Service.DTOs.Attachments;
using Share.Service.DTOs.Users;

namespace Share.Service.DTOs.UserProfileImages;

public class UserProfileImageResultDto
{
    public long Id { get; set; }
    public AttachmentResultDto Attachment { get; set; }
    public UserResultDto User { get; set; }
}
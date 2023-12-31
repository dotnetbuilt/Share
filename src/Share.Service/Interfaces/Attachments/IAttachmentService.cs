using Microsoft.AspNetCore.Http;
using Share.Domain.Entities.Attachments;

namespace Share.Service.Interfaces.Attachments;

public interface IAttachmentService
{
    ValueTask<Attachment> UploadImageAsync(IFormFile image);
    ValueTask<Attachment> RetrieveByIdAsync(long imageId);
}
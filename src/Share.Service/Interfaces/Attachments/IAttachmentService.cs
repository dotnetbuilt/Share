using Microsoft.AspNetCore.Http;
using Share.Domain.Entities.Attachments;

namespace Share.Service.Interfaces.Attachments;

public interface IAttachmentService
{
    ValueTask<Attachment> UploadImageAsync(IFormFile image);
    ValueTask<bool> DestroyAsync(long imageId);
    ValueTask<Attachment> RetrieveByIdAsync(long imageId);
}
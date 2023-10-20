using Microsoft.AspNetCore.Http;
using Share.Domain.Entities.Attachments;

namespace Share.Service.Interfaces;

public interface IAttachmentService
{
    ValueTask<Attachment> UploadImageAsync(IFormFile image);
    ValueTask<bool> RemoveImageAsync(long imageId);
    ValueTask<Attachment> RetrieveByIdAsync(long imageId);
}
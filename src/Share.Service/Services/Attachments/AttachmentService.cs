using Microsoft.AspNetCore.Http;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.Attachments;
using Share.Service.Exceptions;
using Share.Service.Extensions;
using Share.Service.Helpers;
using Share.Service.Interfaces.Attachments;

namespace Share.Service.Services.Attachments;

public class AttachmentService:IAttachmentService
{
    private readonly IUnitOfWork _unitOfWork;
     
    public AttachmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Attachment> UploadImageAsync(IFormFile image)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath, "Images");

        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileName = MediaHelper.MakeImageName(image.FileName);
        var filePath = Path.Combine(webRootPath, fileName);

        var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(image.ToByte());

        var createdAttachment = new Attachment
        {
            FileName = fileName,
            FilePath = filePath
        };

        await _unitOfWork.AttachmentRepositroy.CreateAsync(createdAttachment);
        await _unitOfWork.SaveAsync();

        return createdAttachment;
    }

    public async ValueTask<Attachment> RetrieveByIdAsync(long imageId)
    {
        var existImage =
            await _unitOfWork.AttachmentRepositroy.SelectAsync(expression: attachment => attachment.Id == imageId)
            ?? throw new NotFoundException(message: "Attachment is not found");

        return existImage;
    }
}
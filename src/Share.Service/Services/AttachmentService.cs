using AutoMapper;
using Microsoft.AspNetCore.Http;
using Share.DataAccess.Contracts;
using Share.Domain.Entities;
using Share.Service.DTOs.Attachments;
using Share.Service.Exceptions;
using Share.Service.Extensions;
using Share.Service.Helpers;
using Share.Service.Interfaces;

namespace Share.Service.Services;

public class AttachmentService:IAttachmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
     
    public AttachmentService(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

        var createdAttachment = new Attachment()
        {
            FileName = fileName,
            FilePath = filePath
        };

        await _unitOfWork.AttachmentRepositroy.CreateAsync(createdAttachment);
        await _unitOfWork.SaveAsync();

        return createdAttachment;
    }

    public async ValueTask<bool> RemoveImageAsync(long imageId)
    {
        var existImage =
            await _unitOfWork.AttachmentRepositroy.SelectAsync(expression: image => image.Id == imageId);

        if (existImage == null)
            throw new NotFoundException(message: "Attachment is not found");
        
        _unitOfWork.AttachmentRepositroy.Delete(entity:existImage);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Attachment> RetrieveByIdAsync(long imageId)
    {
        var existImage =
            await _unitOfWork.AttachmentRepositroy.SelectAsync(expression: attachment => attachment.Id == imageId)
            ?? throw new NotFoundException(message: "Attachment is not found");

        return existImage;
    }
}
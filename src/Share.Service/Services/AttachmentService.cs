using AutoMapper;
using Microsoft.AspNetCore.Http;
using Share.DataAccess.Contracts;
using Share.Domain.Entities;
using Share.Service.Interfaces;

namespace Share.Service.Services;

public class AttachmentService:IAttachmentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Attachment> _repository;

    public AttachmentService(IMapper mapper, IRepository<Attachment> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async ValueTask<Attachment> UploadImageAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> RemoveImageAsync(long imageId)
    {
        throw new NotImplementedException();
    }
}
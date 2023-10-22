using AutoMapper;
using Microsoft.AspNetCore.Http;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.StoryImages;
using Share.Service.DTOs.StoryImages;
using Share.Service.Exceptions;
using Share.Service.Interfaces.Attachments;
using Share.Service.Interfaces.StoryImages;

namespace Share.Service.Services.StoryImages;

public class StoryImageService:IStoryImageService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAttachmentService _attachmentService;

    public StoryImageService(IMapper mapper, IUnitOfWork unitOfWork, IAttachmentService attachmentService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _attachmentService = attachmentService;
    }

    public async ValueTask<StoryImageResultDto> AddAsync(long storyId,IFormFile image)
    {
        var existStory = 
            await _unitOfWork.StoryRepository.
                SelectAsync(expression: story => story.Id == storyId,includes:new[]{"User"})
                         ?? throw new NotFoundException(message: "Story is not found");

        var storyImage = await _attachmentService.UploadImageAsync(image);

        var mappedImage = new StoryImage
        {
            StoryId = existStory.Id,
            Story = existStory,
            Attachment = storyImage,
            AttachmentId = storyImage.Id
        };

        await _unitOfWork.StoryImageRepository.CreateAsync(entity: mappedImage);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<StoryImageResultDto>(source: mappedImage);
    }

    public async ValueTask<StoryImageResultDto> RetrieveByIdAsync(long storyImageId)
    {
        var existImage =
            await _unitOfWork.StoryImageRepository.
                SelectAsync(expression: image => image.Id == storyImageId,includes:new[]{"Story.User","Attachment"}) ??
            throw new NotFoundException(message: "Story image is not found");

        return _mapper.Map<StoryImageResultDto>(source: existImage);
    }

    public async ValueTask<bool> RemoveAsync(long storyImageId)
    {
        var existImage =
            await _unitOfWork.StoryImageRepository.
                SelectAsync(expression: image => image.Id == storyImageId) ??
            throw new NotFoundException(message: "Story image is not found");
        
        _unitOfWork.StoryImageRepository.Delete(entity:existImage);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
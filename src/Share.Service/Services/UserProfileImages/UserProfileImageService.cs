using AutoMapper;
using Microsoft.AspNetCore.Http;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.UserProfileImages;
using Share.Service.DTOs.UserProfileImages;
using Share.Service.Exceptions;
using Share.Service.Interfaces.Attachments;
using Share.Service.Interfaces.UserProfileImages;

namespace Share.Service.Services.UserProfileImages;

public class UserProfileImageService:IUserProfileImageService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAttachmentService _attachmentService;

    public UserProfileImageService(IMapper mapper, IUnitOfWork unitOfWork,IAttachmentService attachmentService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _attachmentService = attachmentService;
    }

    public async ValueTask<UserProfileImageResultDto> AddAsync(long userId,IFormFile image)
    {
        var existUser = 
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == userId) ??
                        throw new NotFoundException(message: "User is not found");
        
        var existImage = await _unitOfWork.UserProfileImageRepository
            .SelectAsync(expression: userImage => userImage.UserId == userId);

        if (existImage != null)
            throw new AlreadyExistsException(message: "Profile has already image");

        var profileImage = await _attachmentService.UploadImageAsync(image);

        var mappedImage = new UserProfileImage
        {
            UserId = userId,
            User = existUser,
            AttachmentId = profileImage.Id,
            Attachment = profileImage
        };

        await _unitOfWork.UserProfileImageRepository.CreateAsync(entity:mappedImage);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserProfileImageResultDto>(source: mappedImage);
    }

    public async ValueTask<UserProfileImageResultDto> RetrieveByIdAsync(long imageId)
    {
        var existImage =
            await _unitOfWork.UserProfileImageRepository.SelectAsync(expression: image => image.Id == imageId,
                includes:new[]{"User","Attachment"})
            ?? throw new NotFoundException(message: "UserProfileImage is not found");

        var result = _mapper.Map<UserProfileImageResultDto>(source: existImage);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long imageId)
    {
        var existImage =
            await _unitOfWork.UserProfileImageRepository.SelectAsync(expression: image => image.Id == imageId)
            ?? throw new NotFoundException(message: "UserProfileImage is not found");

        _unitOfWork.UserProfileImageRepository.Delete(entity:existImage);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}
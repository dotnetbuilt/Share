using AutoMapper;
using Share.DataAccess.Contracts;
using Share.Domain.Entities;
using Share.Service.DTOs.UserProfileImages;
using Share.Service.Exceptions;
using Share.Service.Interfaces;

namespace Share.Service.Services;

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

    public async ValueTask<UserProfileImageResultDto> AddAsync(UserProfileImageCreationDto dto)
    {
        var existImage = await _unitOfWork.UserProfileImageRepository
            .SelectAsync(expression: image => image.UserId == dto.UserId);

        if (existImage != null)
            throw new AlreadyExistsException(message: "Profile has already image");

        var profileImage = await _attachmentService.UploadImageAsync(dto.ProfileImage);

        var mappedImage = _mapper.Map<UserProfileImage>(source: dto);
        mappedImage.AttachmentId = profileImage.Id;
        mappedImage.Attachment = profileImage;

        await _unitOfWork.UserProfileImageRepository.CreateAsync(entity:mappedImage);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserProfileImageResultDto>(source: mappedImage);
    }

    public async ValueTask<UserProfileImageResultDto> RetrieveByIdAsync(long imageId)
    {
        var existImage =
            await _unitOfWork.UserProfileImageRepository.SelectAsync(expression: image => image.Id == imageId)
            ?? throw new NotFoundException(message: "UserProfileImage is not found");

        return _mapper.Map<UserProfileImageResultDto>(source: existImage);
    }

    public async ValueTask<bool> RemoveAsync(long imageId)
    {
        var existImage =
            await _unitOfWork.UserProfileImageRepository.SelectAsync(expression: image => image.Id == imageId)
            ?? throw new NotFoundException(message: "UserProfileImage is not found");

        return true;
    }
}
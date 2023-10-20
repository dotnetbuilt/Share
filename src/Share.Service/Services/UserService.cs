using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contracts;
using Share.Domain.Entities;
using Share.Service.DTOs.Users;
using Share.Service.Exceptions;
using Share.Service.Helpers;
using Share.Service.Interfaces;

namespace Share.Service.Services;

public class UserService:IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var existUser = 
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Email == dto.Email);

        if (existUser != null)
            throw new AlreadyExistsException(message: "Email is already taken");

        var mappedUser = _mapper.Map<User>(source: dto);
        mappedUser.Password = PasswordHasher.Hash(mappedUser.Password);

        await _unitOfWork.UserRepository.CreateAsync(entity: mappedUser);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(source: mappedUser);
    }

    public async ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var existUser = 
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.Id)
                        ?? throw new NotFoundException(message: "User is not found");

        var mappedUser = _mapper.Map(source:dto,destination:existUser);
        
        _unitOfWork.UserRepository.Update(entity:mappedUser);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(source: mappedUser);
    }

    public async ValueTask<bool> RemoveAsync(long userId)
    {
        var existUser =
            await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == userId)
                        ?? throw new NotFoundException(message: "User is not found");
        
        _unitOfWork.UserRepository.Delete(entity:existUser);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<UserResultDto> RetrieveByIdAsync(long userId)
    {
        var existUser = await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == userId)
                        ?? throw new NotFoundException(message: "User is not found");

        return _mapper.Map<UserResultDto>(source: existUser);
    }

    public async ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var users = await _unitOfWork.UserRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<UserResultDto>>(source: users);
    }

    public async ValueTask<long> RetrieveNumberOfUsers()
        => await _unitOfWork.UserRepository.SelectAll().LongCountAsync();
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.DTOs.Users;
using Share.Service.Interfaces.Users;

namespace Share.Api.Controllers.Users;

public class UsersController:BaseController
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async ValueTask<IActionResult> RegisterAsync(UserCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });

    [AllowAnonymous]
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(UserUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(dto)
        });

    [AllowAnonymous]
    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(userId)
        });

    [AllowAnonymous]
    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(userId)
        });

    [AllowAnonymous]
    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllAsync()
        });

    [AllowAnonymous]
    [HttpGet("get-number-of-users")]
    public async ValueTask<IActionResult> GetNumberOfUsersAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveNumberOfUsers()
        });

    [AllowAnonymous]
    [HttpPatch("change-password")]
    public async ValueTask<IActionResult> ChangePassword(string email, string currentPassword, string newPassword)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ChangePassword(email, currentPassword, newPassword)
        });
}
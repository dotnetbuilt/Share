using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.Interfaces.UserProfileImages;

namespace Share.Api.Controllers.UserProfiles;

public class UserProfileImagesController:BaseController
{
    private readonly IUserProfileImageService _service;

    public UserProfileImagesController(IUserProfileImageService service)
    {
        _service = service;
    }

    [HttpPost("upload")]
    public async ValueTask<IActionResult> UploadAsync(long userId,IFormFile image)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(userId,image)
        });

    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long imageId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(imageId)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long imageId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(imageId)
        });

    [HttpDelete("destroy")]
    public async ValueTask<IActionResult> DestroyAsync(long profileImageId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.DestroyAsync(profileImageId)
        });
}
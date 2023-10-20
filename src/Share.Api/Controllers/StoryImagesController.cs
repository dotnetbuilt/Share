using Microsoft.AspNetCore.Mvc;
using Share.Api.Models;
using Share.Service.Interfaces;

namespace Share.Api.Controllers;

public class StoryImagesController:BaseController
{
    private readonly IStoryImageService _service;

    public StoryImagesController(IStoryImageService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(long storyId, IFormFile image)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(storyId, image)
        });

    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long storyImageId)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(storyImageId)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long storyImageId)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(storyImageId)
        });
}
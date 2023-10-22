using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.DTOs.LikedStories;
using Share.Service.Interfaces.LikedStories;

namespace Share.Api.Controllers.LikedStories;

public class LikedStoriesController : BaseController
{
    private readonly ILikedStoryService _service;

    public LikedStoriesController(ILikedStoryService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(LikedStoryCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long likedStoryId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(likedStoryId)
        });

    [HttpGet("get-all-by-story-id")]
    public async ValueTask<IActionResult> GetAllByStoryIdAsync(long storyId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllByStoryIdAsync(storyId)
        });

    [HttpGet("get-all-by-user-id")]
    public async ValueTask<IActionResult> GetAllUserIdAsync(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllByUserIdAsync(userId)
        });

    [HttpGet("get-number-of-likes-by-story-id")]
    public async ValueTask<IActionResult> GetNumberOfLikesByStoryIdAsync(long storyId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveNumberOfLikesByStoryIdAsync(storyId)
        });
}
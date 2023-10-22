using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.DTOs.SavedStories;
using Share.Service.Interfaces.SavedStories;

namespace Share.Api.Controllers.SavedStories;

public class SavedStoriesController:BaseController
{
    private readonly ISavedStoryService _service;

    public SavedStoriesController(ISavedStoryService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(SavedStoryCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long savedStoryId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(savedStoryId)
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
    public async ValueTask<IActionResult> GetAllByUserIdAsync(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllByUserIdAsync(userId)
        });

    [HttpGet("get-number-of-users-by-story-id")]
    public async ValueTask<IActionResult> GetNumberOfUsersByStoryIdAsync(long storyId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveNumberOfUsersByStoryIdAsync(storyId)
        });

    [HttpDelete("destroy")]
    public async ValueTask<IActionResult> DestroyAsync(long savedStoryId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.DestroyAsync(savedStoryId)
        });
}
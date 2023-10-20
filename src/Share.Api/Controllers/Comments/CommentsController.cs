using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.DTOs.Comments;
using Share.Service.Interfaces.Comments;

namespace Share.Api.Controllers.Comments;

public class CommentsController:BaseController
{
    private readonly ICommentService _service;

    public CommentsController(ICommentService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(CommentCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });

    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(CommentUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(dto)
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
}
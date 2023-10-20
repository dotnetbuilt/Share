using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.DTOs.Follows;
using Share.Service.Interfaces.Follows;

namespace Share.Api.Controllers.Follows;

public class FollowsController:BaseController
{
    private readonly IFollowService _service;

    public FollowsController(IFollowService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(FollowCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long followId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(followId)
        });

    [HttpGet("get-all-followings")]
    public async ValueTask<IActionResult> GetAllFollowingsByFollowerIdAsync(long followerId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllFollowingsByFollowerIdAsync(followerId)
        });
    
    [HttpGet("get-all-followers")]
    public async ValueTask<IActionResult> GetAllFollowersByFollowingIdAsync(long followingId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllFollowersByFollowingIdAsync(followingId)
        });

    [HttpGet("get-number-of-followings")]
    public async ValueTask<IActionResult> GetNumberOfFollowingsByFollowerId(long followerId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveNumberOfFollowingsAsync(followerId)
        });
    
    [HttpGet("get-number-of-followers")]
    public async ValueTask<IActionResult> GetNumberOfFollowersByFollowingId(long followingId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveNumberOfFollowersAsync(followingId)
        });
}
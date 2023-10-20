using Microsoft.AspNetCore.Mvc;
using Share.Api.Models;
using Share.Service.Interfaces;

namespace Share.Api.Controllers;

public class AttachmentsController : BaseController
{
    private readonly IAttachmentService _service;

    public AttachmentsController(IAttachmentService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(IFormFile image)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.UploadImageAsync(image)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long imageId)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveImageAsync(imageId)
        });
}
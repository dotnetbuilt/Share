using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.Interfaces.Attachments;

namespace Share.Api.Controllers.Attachments;

public class AttachmentsController : BaseController
{
    private readonly IAttachmentService _service;

    public AttachmentsController(IAttachmentService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(IFormFile image)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.UploadImageAsync(image)
        });

    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long imageId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(imageId)
        });
}
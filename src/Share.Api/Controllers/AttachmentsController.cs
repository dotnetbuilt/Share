using Microsoft.AspNetCore.Mvc;

namespace Share.Api.Controllers;

public class AttachmentsController:BaseController
{
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync([FromForm] IFormFile image)
        => Ok()
}
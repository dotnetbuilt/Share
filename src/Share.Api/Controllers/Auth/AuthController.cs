using Microsoft.AspNetCore.Mvc;
using Share.Api.Controllers.Commons;
using Share.Api.Models;
using Share.Service.Interfaces.Auth;

namespace Share.Api.Controllers.Auth;

public class AuthController:BaseController
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> LoginAsync(string email, string password)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.GenerateTokenAsync(email, password)
        });
}
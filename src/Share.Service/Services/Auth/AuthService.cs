using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Share.DataAccess.Contracts;
using Share.Service.Exceptions;
using Share.Service.Helpers;
using Share.Service.Interfaces.Auth;

namespace Share.Service.Services.Auth;

public class AuthService:IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public AuthService(IUnitOfWork unitOfWork,IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async ValueTask<string> GenerateTokenAsync(string email, string password)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Email == email) ??
                   throw new NotFoundException(message: "User is not found");

        var isPasswordVerified = PasswordHasher.Verify(currentPassword:user.Password,checkingPassword:password);
        if (isPasswordVerified == false)
            throw new CustomException(message: "Password is incorrect",statusCode:404);
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
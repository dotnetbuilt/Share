namespace Share.Service.Interfaces.Auth;

public interface IAuthService
{
    ValueTask<string> GenerateTokenAsync(string email, string password);
}
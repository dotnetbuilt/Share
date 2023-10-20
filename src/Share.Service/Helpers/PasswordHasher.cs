namespace Share.Service.Helpers;

public static class PasswordHasher
{
    public static string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public static bool Verify(string currentPassword, string originalPassword)
        => BCrypt.Net.BCrypt.Verify(currentPassword, originalPassword);
}
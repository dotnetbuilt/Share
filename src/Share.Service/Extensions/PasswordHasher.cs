namespace Share.Service.Extensions;

public static class PasswordHasher
{
    public static string Hash(this string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public static bool Verify(this string currentPassword, string originalPassword)
        => BCrypt.Net.BCrypt.Verify(currentPassword, originalPassword);
}
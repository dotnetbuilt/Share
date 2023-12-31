namespace Share.Service.Helpers;

public static class PasswordHasher
{
    public static string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public static bool Verify(string checkingPassword, string currentPassword)
        => BCrypt.Net.BCrypt.Verify(checkingPassword, currentPassword);
}
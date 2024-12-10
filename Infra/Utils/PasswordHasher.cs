using System.Security.Cryptography;
using System.Text;

namespace Infra.Utils;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var hashedBytes = sha256.ComputeHash(passwordBytes);
        return Convert.ToBase64String(hashedBytes);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var hashOfInput = HashPassword(password);
        return hashOfInput == hashedPassword;
    }
}
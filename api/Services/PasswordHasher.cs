using Microsoft.AspNetCore.Identity;

namespace RegistrationApi.Services;

public class PasswordHasher : IPasswordHasher
{
    private readonly Microsoft.AspNetCore.Identity.PasswordHasher<object> _hasher;

    public PasswordHasher()
    {
        _hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<object>();
    }

    public string HashPassword(string password)
    {
        return _hasher.HashPassword(new object(), password);
    }

    public bool VerifyPassword(string password, string hash)
    {
        var result = _hasher.VerifyHashedPassword(new object(), hash, password);
        return result == PasswordVerificationResult.Success;
    }
}
using Microsoft.AspNetCore.DataProtection;

namespace Hashing.Utilities;

public class PiiProtector : IPiiProtector
{
    private readonly IDataProtector _protector;

    public PiiProtector(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector("API.Students");
    }

    public string Protect(string plain)
        => string.IsNullOrWhiteSpace(plain) ? "" : _protector.Protect(plain.Trim());

    public string Unprotect(string cipher)
        => string.IsNullOrWhiteSpace(cipher) ? "" : _protector.Unprotect(cipher);

    public string HashForLookup(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";
        using var sha = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(input.Trim().ToLowerInvariant());
        return Convert.ToHexString(sha.ComputeHash(bytes));
    }
}
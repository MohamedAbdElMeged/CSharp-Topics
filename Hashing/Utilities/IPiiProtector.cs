namespace Hashing.Utilities;

public interface IPiiProtector
{
    string Protect(string plain);
    string Unprotect(string cipher);
    string HashForLookup(string input);
}
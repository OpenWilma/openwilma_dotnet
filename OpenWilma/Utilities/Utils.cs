using System.Text;
using System.Security.Cryptography;

namespace OpenWilma.Utilities;

public static class Utils
{
    public static string DeriveSHA1Digest(string input)
    {
        Span<byte> hash = stackalloc byte[20];
        SHA1.HashData(Encoding.UTF8.GetBytes(input), hash);

        return Convert.ToHexString(hash).ToLower();
    }
}

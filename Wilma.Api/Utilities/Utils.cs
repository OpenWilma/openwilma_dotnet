using System.Text;
using System.Security.Cryptography;

namespace Wilma.Api.Utilities
{
    public static class Utils
    {
        public static string DeriveSHA1Digest(string input)
        {
            using var sha1 = SHA1.Create();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

using System.Text;
using System.Security.Cryptography;

namespace Wilma.Api.Utilities
{
    public static class Helper
    {
        public static string SHA1Hash(string input)
        {
            using (var sha1 = new SHA1Managed())
            {
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
}

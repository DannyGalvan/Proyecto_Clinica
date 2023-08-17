using System.Net.Mail;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace Business.Repository
{
    public class Resources
    {
        public static string ConvertSha256(string text)
        {
            StringBuilder sb = new();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}

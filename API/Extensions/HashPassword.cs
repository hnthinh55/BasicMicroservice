using System.Text;
using System.Security.Cryptography;
namespace API.Extensions
{
    public class HashPassword
    {
        public string HashMD5(string password)
        {
            StringBuilder hash = new StringBuilder();

            // input string

            // defining MD5 object
            var md5provider = new MD5CryptoServiceProvider();
            // computing MD5 hash
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            // final output
            return hash.ToString();
        }
    }
}

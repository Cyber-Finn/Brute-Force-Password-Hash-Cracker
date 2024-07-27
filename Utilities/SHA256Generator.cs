using System.Text;
using System.Security.Cryptography;

namespace MultiArrayTest.Utilities
{
    public class SHA256Generator
    {
        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                //Convert the hash bytes to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Format as two hex characters
                }
                return sb.ToString();
            }
        }
    }
}

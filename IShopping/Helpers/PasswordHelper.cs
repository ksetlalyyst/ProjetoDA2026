using System.Security.Cryptography;
using System.Text;

namespace iShopping.Helpers
{
    public static class PasswordHelper
    {
        public static string Hash(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            var sb = new StringBuilder();
            foreach (var b in bytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public static bool Verificar(string password, string hash)
        {
            return Hash(password) == hash;
        }
    }
}

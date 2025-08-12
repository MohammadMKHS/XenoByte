using System.Security.Cryptography;
using System.Text;

namespace XenoByte.Helpers
{
    public static class PasswordHelper
    {
        // Hash password with salt
        public static (string hashedPassword, string salt) HashPassword(string password)
        {
            // Generate random salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Combine password + salt
            var combined = password + salt;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                string hashedPassword = Convert.ToBase64String(hashBytes);
                return (hashedPassword, salt);
            }
        }

        // Verify password by hashing again with stored salt
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var combined = password + storedSalt;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                string hashToCheck = Convert.ToBase64String(hashBytes);
                return hashToCheck == storedHash;
            }
        }
    }
}

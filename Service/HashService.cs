using System.Security.Cryptography;

namespace UserCrudWithAspDotNetCoreWithAngular.Service
{
    public class HashService : IHashService
    {
        private const int SaltSize = 32;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        // Method to generate a random salt
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // Method to hash the password using PBKDF2

        public (string hashedPassword, string salt) HashPassword(string password)
        {
            byte[] salt = GenerateSalt();
            byte[] hashBytes = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256).GetBytes(HashSize);

            return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(salt));
        }

        // Method to verify the password against the hash
        public static bool VerifyPassword(string password, string hash, string salt)
        {
            byte[] hashBytes = Convert.FromBase64String(hash);
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] newHashBytes = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256).GetBytes(HashSize);

            // Compare the generated hash with the stored hash
            return SlowEquals(hashBytes, newHashBytes);
        }

        // Method to compare two byte arrays to prevent timing attacks
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

    }
}

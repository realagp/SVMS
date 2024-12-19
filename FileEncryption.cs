using System.IO;
using System.Security.Cryptography;

namespace SVMS
{
    public class FileEncryption
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;

        public static void EncryptFile(string inputFilePath, string outputFilePath, string password)
        {
            using (var aes = Aes.Create())
            {
                byte[] salt = GenerateSalt();
                aes.Key = GenerateKey(password, salt);
                aes.GenerateIV();

                using (var fileStream = new FileStream(outputFilePath, FileMode.Create))
                {
                    fileStream.Write(salt, 0, salt.Length);
                    fileStream.Write(aes.IV, 0, aes.IV.Length);

                    using (var cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var inputStream = new FileStream(inputFilePath, FileMode.Open))
                    {
                        inputStream.CopyTo(cryptoStream);
                    }
                }
            }
        }

        public static void DecryptFile(string inputFilePath, string outputFilePath, string password)
        {
            using (var fileStream = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] salt = new byte[SaltSize];
                fileStream.Read(salt, 0, SaltSize);

                byte[] iv = new byte[16];
                fileStream.Read(iv, 0, iv.Length);

                using (var aes = Aes.Create())
                {
                    aes.Key = GenerateKey(password, salt);
                    aes.IV = iv;

                    using (var cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (var outputStream = new FileStream(outputFilePath, FileMode.Create))
                    {
                        cryptoStream.CopyTo(outputStream);
                    }
                }
            }
        }

        private static byte[] GenerateSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                return salt;
            }
        }
        private static byte[] GenerateKey(string password, byte[] salt)
        {
            using (var keyDerivation = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                return keyDerivation.GetBytes(KeySize);
            }
        }
    }
}

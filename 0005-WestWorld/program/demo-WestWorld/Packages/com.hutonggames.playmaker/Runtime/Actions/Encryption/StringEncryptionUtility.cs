using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HutongGames.PlayMaker.Actions
{
    internal static class StringEncryptionUtility
    {
        private const string Prefix = "PMENC1:";
        private const int SaltSize = 16;
        private const int IvSize = 16;
        private const int KeySize = 32;
        private const int HmacSize = 32;
        private const int Iterations = 100000;

        public static bool TryEncrypt(string text, string passphrase, out string encrypted)
        {
            encrypted = string.Empty;

            if (string.IsNullOrEmpty(passphrase))
                return false;

            try
            {
                var salt = CreateRandomBytes(SaltSize);
                var iv = CreateRandomBytes(IvSize);
                var keys = DeriveKeys(passphrase, salt);
                var plainBytes = Encoding.UTF8.GetBytes(text ?? string.Empty);
                var cipherBytes = EncryptBytes(plainBytes, keys.EncryptionKey, iv);
                var payloadWithoutHmac = Combine(salt, iv, cipherBytes);
                var hmac = ComputeHmac(payloadWithoutHmac, keys.HmacKey);

                encrypted = Prefix + Convert.ToBase64String(Combine(payloadWithoutHmac, hmac));
                return true;
            }
            catch
            {
                encrypted = string.Empty;
                return false;
            }
        }

        public static bool TryDecrypt(string encrypted, string passphrase, out string text)
        {
            text = string.Empty;

            if (string.IsNullOrEmpty(encrypted) || string.IsNullOrEmpty(passphrase))
                return false;

            if (!encrypted.StartsWith(Prefix, StringComparison.Ordinal))
                return false;

            try
            {
                var payload = Convert.FromBase64String(encrypted.Substring(Prefix.Length));
                if (payload.Length <= SaltSize + IvSize + HmacSize)
                    return false;

                var payloadLength = payload.Length - HmacSize;
                var payloadWithoutHmac = new byte[payloadLength];
                var storedHmac = new byte[HmacSize];
                Buffer.BlockCopy(payload, 0, payloadWithoutHmac, 0, payloadWithoutHmac.Length);
                Buffer.BlockCopy(payload, payloadWithoutHmac.Length, storedHmac, 0, storedHmac.Length);

                var salt = new byte[SaltSize];
                var iv = new byte[IvSize];
                var cipherLength = payloadWithoutHmac.Length - SaltSize - IvSize;
                var cipherBytes = new byte[cipherLength];
                Buffer.BlockCopy(payloadWithoutHmac, 0, salt, 0, salt.Length);
                Buffer.BlockCopy(payloadWithoutHmac, salt.Length, iv, 0, iv.Length);
                Buffer.BlockCopy(payloadWithoutHmac, salt.Length + iv.Length, cipherBytes, 0, cipherBytes.Length);

                var keys = DeriveKeys(passphrase, salt);
                var computedHmac = ComputeHmac(payloadWithoutHmac, keys.HmacKey);
                if (!FixedTimeEquals(storedHmac, computedHmac))
                    return false;

                var plainBytes = DecryptBytes(cipherBytes, keys.EncryptionKey, iv);
                text = Encoding.UTF8.GetString(plainBytes);
                return true;
            }
            catch
            {
                text = string.Empty;
                return false;
            }
        }

        private static EncryptionKeys DeriveKeys(string passphrase, byte[] salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(passphrase, salt, Iterations, HashAlgorithmName.SHA256))
            {
                var keyBytes = deriveBytes.GetBytes(KeySize + KeySize);
                var encryptionKey = new byte[KeySize];
                var hmacKey = new byte[KeySize];
                Buffer.BlockCopy(keyBytes, 0, encryptionKey, 0, encryptionKey.Length);
                Buffer.BlockCopy(keyBytes, encryptionKey.Length, hmacKey, 0, hmacKey.Length);
                return new EncryptionKeys(encryptionKey, hmacKey);
            }
        }

        private static byte[] EncryptBytes(byte[] plainBytes, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = KeySize * 8;
                aes.BlockSize = IvSize * 8;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor())
                using (var output = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(output, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                    }

                    return output.ToArray();
                }
            }
        }

        private static byte[] DecryptBytes(byte[] cipherBytes, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = KeySize * 8;
                aes.BlockSize = IvSize * 8;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor())
                using (var input = new MemoryStream(cipherBytes))
                using (var cryptoStream = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
                using (var output = new MemoryStream())
                {
                    cryptoStream.CopyTo(output);
                    return output.ToArray();
                }
            }
        }

        private static byte[] ComputeHmac(byte[] bytes, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(bytes);
            }
        }

        private static byte[] CreateRandomBytes(int length)
        {
            var bytes = new byte[length];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return bytes;
        }

        private static byte[] Combine(params byte[][] arrays)
        {
            var length = 0;
            foreach (var array in arrays)
                length += array.Length;

            var combined = new byte[length];
            var offset = 0;
            foreach (var array in arrays)
            {
                Buffer.BlockCopy(array, 0, combined, offset, array.Length);
                offset += array.Length;
            }

            return combined;
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            var diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }

        private struct EncryptionKeys
        {
            public readonly byte[] EncryptionKey;
            public readonly byte[] HmacKey;

            public EncryptionKeys(byte[] encryptionKey, byte[] hmacKey)
            {
                EncryptionKey = encryptionKey;
                HmacKey = hmacKey;
            }
        }
    }
}

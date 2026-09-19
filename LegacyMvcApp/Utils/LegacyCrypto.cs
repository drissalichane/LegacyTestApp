using System;
using System.Security.Cryptography;

namespace LegacyMvcApp.Utils
{
    public class LegacyCrypto
    {
        public byte[] GenerateRandomBytes()
        {
            // RNGCryptoServiceProvider is obsolete
#pragma warning disable SYSLIB0023
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[32];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
#pragma warning restore SYSLIB0023
        }

        public byte[] HashData(byte[] data)
        {
            // SHA1Managed is obsolete
#pragma warning disable SYSLIB0021
            using (var sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(data);
            }
#pragma warning restore SYSLIB0021
        }
    }
}

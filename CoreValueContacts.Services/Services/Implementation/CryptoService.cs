using CoreValueContacts.Services.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CoreValueContacts.Services.Services.Implementation
{
    public class CryptoService : ICryptoService
    {
        public string GenerateSalt()
        {
            var data = new byte[0x10];

            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        public string EncryptPassword(string salt, string password)
        {
            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentNullException("salt");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);

                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);

                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
    }
}

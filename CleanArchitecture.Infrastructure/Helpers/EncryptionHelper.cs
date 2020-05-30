using CleanArchitecture.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Infrastructure.Helpers
{
    public class EncryptionHelper
    {
        private SecurityProvider securityProvider;

        private string salt;

        public EncryptionHelper(SecurityProvider securityProvider)
        {
            this.securityProvider = securityProvider;
            this.salt = this.securityProvider.PasswordSalt;
        }

        public string EncryptPassword(string password)
        {

            var hash = MD5.Create();
            var pass = this.salt + password;
            var bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(pass));
            var encrypted = BitConverter.ToString(bytes);
            var result = encrypted.Replace("-", "");
                
            return result;
        }
    }
}

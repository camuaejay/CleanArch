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

        public EncryptionHelper(SecurityProvider securityProvider)
        {
            this.securityProvider = securityProvider;
        }

        public string EncryptPassword(string password)
        {

            var hash = MD5.Create();
            var pass = this.securityProvider.PasswordSalt + password;
            var bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(pass));
            var encrypted = BitConverter.ToString(bytes);
            var result = encrypted.Replace("-", "");
                
            return result;
        }
    }
}

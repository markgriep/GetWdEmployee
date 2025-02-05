using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WDEmployee.Services
{
    internal static class SecretsManager
    {

        public static string GetSecret(string theSecretName)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
.                   Build();

            string secretValue = configuration[theSecretName];
            return secretValue;
        }



        public static string GetBase64CredentialsFromSecrets(string userSecretName, string passwordSecretName)
        {
            string _creds = $"{GetSecret(userSecretName)}:{GetSecret(passwordSecretName)}";
            byte[] _bytes = System.Text.Encoding.UTF8.GetBytes(_creds);
            var _base64Credentials = System.Convert.ToBase64String(_bytes);
            return _base64Credentials;
        }





    }
}

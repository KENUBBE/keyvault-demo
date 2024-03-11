using keyvault_demo.Interfaces;
using keyvault_demo.Models;
using Microsoft.Extensions.Options;

namespace keyvault_demo.Services
{
    public class SecretService : ISecretService
    {
        private readonly SecretConfiguration _configuration;

        public SecretService(IOptions<SecretConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public SecretConfiguration GetSecrets()
        {
            return _configuration;
        }
    }
}
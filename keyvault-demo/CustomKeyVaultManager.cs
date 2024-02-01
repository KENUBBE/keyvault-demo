using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;

namespace keyvault_demo
{
    public class CustomKeyVaultManager : KeyVaultSecretManager
    {
        // Exclude disabled and expired secrets
        public override bool Load(SecretProperties properties) =>
          properties.ExpiresOn.HasValue &&
          properties.ExpiresOn.Value > DateTimeOffset.Now;
    }
}

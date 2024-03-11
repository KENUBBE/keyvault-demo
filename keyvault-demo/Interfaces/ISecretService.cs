using keyvault_demo.Models;

namespace keyvault_demo.Interfaces
{
    public interface ISecretService
    {
        SecretConfiguration GetSecrets();
    }
}

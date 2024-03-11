using Azure.Identity;
using keyvault_demo.Interfaces;
using keyvault_demo.Models;
using keyvault_demo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup KeyVault Configuration

var KeyVaultUri = builder.Configuration.GetSection("AzureConfiguration:KeyVaultUri").Value;
var ManagedIdentityClientId = builder.Configuration.GetSection("AzureConfiguration:ManagedIdentityClientId").Value;

if (string.IsNullOrWhiteSpace(KeyVaultUri) || string.IsNullOrWhiteSpace(ManagedIdentityClientId))
{
    throw new ArgumentException("No valid Key Vault Uri or Managed Identity is configured");
}

builder.Configuration.AddAzureKeyVault(
new Uri(KeyVaultUri),
new DefaultAzureCredential(
    new DefaultAzureCredentialOptions
    {
        ManagedIdentityClientId = ManagedIdentityClientId
    })
);

// Setup Secret Configuration

builder.Services.Configure<SecretConfiguration>(builder.Configuration.GetSection("SecretConfiguration"));
builder.Services.AddScoped<ISecretService, SecretService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using keyvault_demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.EnvironmentName == "Test")
{

    //Setup KeyVault Configuration

    var KeyVaultUri = builder.Configuration["KeyVaultUri"];

    if (string.IsNullOrWhiteSpace(KeyVaultUri))
    {
        throw new ArgumentException("No valid Key Vault Uri configured");
    }

    builder.Configuration.AddAzureKeyVault(
    new Uri(KeyVaultUri),
    new DefaultAzureCredential()
    //new AzureKeyVaultConfigurationOptions()
    //{
    //    ReloadInterval = TimeSpan.FromSeconds(20),
    //    Manager = new CustomKeyVaultManager()
    //});
    );


    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

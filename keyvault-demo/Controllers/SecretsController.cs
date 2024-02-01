using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8600

[ApiController]
[Route("api/[controller]")]
public class SecretsController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public SecretsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetSecret()
    {
        try
        {
            string secretValue = _configuration["SecretApiKey"];

            if (string.IsNullOrEmpty(secretValue))
            {
                return NotFound("Secret not found");
            }

            return Ok($"Secret Value: {secretValue}");
        }
        catch
        {
            return NotFound("Secret not found");
        }
    }
}
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SecretController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public SecretController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("Secret")]
    public IActionResult GetSecret()
    {
        var secret = _configuration["MySecret"];
        return Ok(secret);
    }
}
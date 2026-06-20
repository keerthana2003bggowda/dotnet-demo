using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "Hello from .NET API!",
            version = "1.0.0",
            timestamp = DateTime.UtcNow
        });
    }

    [HttpGet("health")]
    public IActionResult Health()
    {
        return Ok(new { status = "UP" });
    }

    [HttpGet("{name}")]
    public IActionResult Greet(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest(new { error = "Name cannot be empty" });

        return Ok(new { message = $"Hello, {name}!" });
    }
}

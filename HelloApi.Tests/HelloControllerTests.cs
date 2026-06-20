using HelloApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Tests;

public class HelloControllerTests
{
    private readonly HelloController _controller;

    public HelloControllerTests()
    {
        _controller = new HelloController();
    }

    [Fact]
    public void Get_ReturnsOkResult()
    {
        var result = _controller.Get();
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Health_ReturnsUpStatus()
    {
        var result = _controller.Health() as OkObjectResult;
        Assert.NotNull(result);
        var body = result.Value!.ToString();
        Assert.Contains("UP", body);
    }

    [Fact]
    public void Greet_ValidName_ReturnsGreeting()
    {
        var result = _controller.Greet("Keerthana") as OkObjectResult;
        Assert.NotNull(result);
        var body = result.Value!.ToString();
        Assert.Contains("Keerthana", body);
    }

    [Fact]
    public void Greet_EmptyName_ReturnsBadRequest()
    {
        var result = _controller.Greet("");
        Assert.IsType<BadRequestObjectResult>(result);
    }
}

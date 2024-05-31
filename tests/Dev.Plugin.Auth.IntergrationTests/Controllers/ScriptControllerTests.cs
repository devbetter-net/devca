using Dev.Plugin.Auth.IntergrationTests.Base;

namespace Dev.Plugin.Auth.IntergrationTests.Controllers;
public class ScriptControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public ScriptControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetScriptAsync_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.GetAnonymousClient();

        // Act
        var response = await client.GetAsync("/api/authen/script");
        string content = await response.Content.ReadAsStringAsync();
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.NotEmpty(content);
    }
}

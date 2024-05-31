using Dev.Plugin.Auth.Core.UseCases.Authenticate;
using Dev.Plugin.Auth.IntergrationTests.Base;
namespace Dev.Plugin.Auth.IntergrationTests.Controllers;

public class LoginControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public LoginControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task LoginAsync_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.GetAnonymousClient();
        SignInCommand signInCommand = new SignInCommand
        {
            Email = "admin@devbetter.net",
            Password = "1qaz!QAZ"
        };
        // Act
        var response = await client.PostAsync("/api/auth/login", Utilities.ConvertToJsonContent(signInCommand));
        // Assert
        response.EnsureSuccessStatusCode();
    }
}

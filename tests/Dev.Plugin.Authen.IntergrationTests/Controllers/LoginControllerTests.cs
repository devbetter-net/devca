using Dev.Plugin.Authen.Core.UseCases.Authenticate;
using Dev.Plugin.Authen.IntergrationTests.Base;
namespace Dev.Plugin.Authen.IntergrationTests.Controllers;

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
        var response = await client.PostAsync("/api/authen/login", Utilities.ConvertToJsonContent(signInCommand));
        // Assert
        response.EnsureSuccessStatusCode();
    }
}

using Dev.Plugin.Auth.Core.UseCases.Authenticate;
using Microsoft.AspNetCore.Authorization;
namespace Dev.Plugin.Auth.Core.Controllers;


public class LoginController : BaseController
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] SignInCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}

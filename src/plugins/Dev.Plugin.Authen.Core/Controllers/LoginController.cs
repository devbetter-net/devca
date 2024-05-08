using Dev.Plugin.Authen.Core.UseCases.Authenticate;
namespace Dev.Plugin.Authen.Core.Controllers;

public class LoginController : BaseController
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] SignInCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}

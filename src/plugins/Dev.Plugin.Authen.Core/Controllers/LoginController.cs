using Dev.Plugin.Authen.Core.UseCases.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Plugin.Authen.Core;

[Route("api/authen/[controller]")]
[ApiController]
public class LoginController : ControllerBase
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

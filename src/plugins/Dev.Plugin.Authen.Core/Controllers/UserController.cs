using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.Controllers;

public class UserController : BaseController
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var users = await _mediator.Send(new GetUserListQuery());
        return Ok(users);
    }
}

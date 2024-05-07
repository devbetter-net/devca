using Dev.Plugin.Authen.Core.UseCases.Users;

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
        var userListQuery = new GetUserListQuery();

        var users = await _mediator.Send(userListQuery);
        return Ok(users);
    }
}

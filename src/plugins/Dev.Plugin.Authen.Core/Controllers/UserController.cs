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
        return Ok(await _mediator.Send(userListQuery));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByAsync(Guid id)
    {
        var userQuery = new GetUserByIdQuery(id);
        return Ok(await _mediator.Send(userQuery));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}/password")]
    public async Task<IActionResult> ChangePasswordAsync(Guid id, [FromBody] ChangePasswordCommand command)
    {
        command.UserId = id;
        await _mediator.Send(command);
        return Ok();
    }
}

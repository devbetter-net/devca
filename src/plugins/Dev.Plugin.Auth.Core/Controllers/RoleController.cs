using Dev.Plugin.Auth.Core.UseCases.Roles;

namespace Dev.Plugin.Auth.Core.Controllers;

public class RoleController : BaseController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoleListAsync([FromQuery] GetRoleListQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleAsync(Guid id)
    {
        return Ok(await _mediator.Send(new GetRoleByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoleAsync(Guid id, [FromBody] UpdateRoleCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("{roleId}/users")]
    public async Task<IActionResult> AddUserToRoleAsync(Guid roleId, [FromBody] AddUserToRoleCommand command)
    {
        command.RoleId = roleId;
        await _mediator.Send(command);
        return Ok();
    }
}

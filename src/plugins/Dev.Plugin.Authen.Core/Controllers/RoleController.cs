using Dev.Plugin.Authen.Core.UseCases.Roles;

namespace Dev.Plugin.Authen.Core.Controllers;

public class RoleController : BaseController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoleList([FromQuery] GetRoleListQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(Guid id)
    {
        return Ok(await _mediator.Send(new GetRoleByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}

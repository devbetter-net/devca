using Dev.Plugin.Blog.Core.UseCases.Categories;

namespace Dev.Plugin.Blog.Core.Controllers;

public class CategoryController : BaseController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(CreateCategoryCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    } 
    [HttpDelete]
    public async Task<IActionResult> DeleteCategoryAsync(DeleteCategoryCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}

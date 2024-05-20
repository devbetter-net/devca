namespace Dev.Plugin.Blog.Core.Controllers;

[ApiController]
[Route("blog/[controller]")]
public class ScriptController : ControllerBase
{
    private readonly ICommonService _commonService;

    public ScriptController(ICommonService commonService)
    {
        _commonService = commonService;
    }

    [HttpGet]
    public IActionResult GetScriptAsync()
    {
        string script = _commonService.GenerateCreateScript();
        return Ok(script);
    }
}

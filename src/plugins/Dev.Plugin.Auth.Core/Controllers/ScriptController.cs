using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core;

[ApiController]
[Route("authen/[controller]")]
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

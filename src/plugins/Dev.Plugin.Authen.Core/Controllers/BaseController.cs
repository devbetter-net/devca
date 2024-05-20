using Microsoft.AspNetCore.Authorization;

namespace Dev.Plugin.Authen.Core.Controllers;


[Authorize]
[Route("authen/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

}

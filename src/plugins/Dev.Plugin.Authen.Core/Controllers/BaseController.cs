using Microsoft.AspNetCore.Authorization;

namespace Dev.Plugin.Authen.Core.Controllers;


[Authorize]
[Route("api/authen/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

}

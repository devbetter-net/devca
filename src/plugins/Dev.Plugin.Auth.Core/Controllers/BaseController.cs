using Microsoft.AspNetCore.Authorization;

namespace Dev.Plugin.Auth.Core.Controllers;


[Authorize]
[Route("auth/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

}

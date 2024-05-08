using Dev.Plugin.Authen.Infrastructure.Data;
using Dev.Infrastructure.Data;

namespace Dev.Plugin.Authen.Infrastructure.Services;

public class CommonService : ICommonService
{
    private readonly AuthenDbContext _context;

    public CommonService(AuthenDbContext context)
    {
        _context = context;
    }

    public string GenerateCreateScript()
    {
        return _context.GenerateCreateScript();
    }
}

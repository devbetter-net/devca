using Dev.Infrastructure.Data;
namespace Dev.Plugin.Blog.Infrastructure.Services;

public class CommonService : ICommonService
{
    private readonly BlogDbContext _context;

    public CommonService(BlogDbContext context)
    {
        _context = context;
    }

    public string GenerateCreateScript()
    {
        return _context.GenerateCreateScript();
    }
}

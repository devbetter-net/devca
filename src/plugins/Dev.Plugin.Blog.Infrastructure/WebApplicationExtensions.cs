using Dev.Plugin.Blog.Core;
using Dev.Plugin.Blog.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dev.Plugin.Blog.Infrastructure;

public static class WebApplicationExtensions
{
    public static void AddBlog(this WebApplicationBuilder builder)
    {
        builder.AddBlogCore();
        //database
        string connectionString = builder.Configuration.GetConnectionString("Blog")!;
        builder.Services.AddDbContext<BlogDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        //services
        builder.Services.AddScoped<ICommonService, CommonService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IPostService, PostService>();
    }

    public static void UseBlog(this WebApplication app)
    {

    }
}
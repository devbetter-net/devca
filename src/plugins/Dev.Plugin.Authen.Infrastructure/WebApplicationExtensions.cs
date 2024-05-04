﻿using Dev.Plugin.Authen.Core;
using Dev.Plugin.Authen.Core.Services;
using Dev.Plugin.Authen.Infrastructure.Data;
using Dev.Plugin.Authen.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dev.Plugin.Authen.Infrastructure;

public static class WebApplicationExtensions
{
    public static void AddAuthen(this WebApplicationBuilder builder)
    {
        builder.AddAuthenCore();
        
        //database
        builder.Services.AddDbContext<AuthenDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Authen"));
        });

        //services
        builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

        //routes
    }


    public static void UseAuthen(this WebApplication app)
    {
    }
}

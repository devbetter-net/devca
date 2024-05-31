using System.Text;
using Dev.Plugin.Auth.Core;
using Dev.Plugin.Auth.Core.Configurations;
using Dev.Plugin.Auth.Infrastructure.Data;
using Dev.Plugin.Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Dev.Plugin.Auth.Infrastructure;

public static class WebApplicationExtensions
{
    public static void AddAuth(this WebApplicationBuilder builder)
    {
        builder.AddAuthCore();
        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));        
        //database
        string connectionString = builder.Configuration.GetConnectionString("Authen")!;
        builder.Services.AddDbContext<AuthenDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        builder.RegisterSwagger();
        //services
        builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IUserService, UserService>();        
        builder.Services.AddScoped<ICommonService, CommonService>();
        //routes
    }

    private static void RegisterSwagger(this WebApplicationBuilder builder)
    {
        var jwtConfig = builder.Services.BuildServiceProvider().GetService<IOptions<JwtConfig>>()!.Value;

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        // Adding Jwt Bearer
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = false,

                ValidAudience = jwtConfig.Audiences,
                ValidIssuer = jwtConfig.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret))
            };
        });

        builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Dev API",
                        Version = "v1"
                    });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Scheme = "bearer",
                        Description = "Please insert JWT token into field"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
                });
    }


    public static void UseAuth(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}

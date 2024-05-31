using Dev.Plugin.Auth.Infrastructure;
using Dev.Plugin.Blog.Infrastructure;
using Dev.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.AddAuth(); //add authenticate and authorize
builder.AddBlog(); //add blog plugin module

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials
    
app.MapControllers();

app.UseAuth(); //use authenticate and authorize
app.UseBlog(); //use blog plugin module
app.UseCustomExceptionHandler();
app.Run();

public partial class Program { }
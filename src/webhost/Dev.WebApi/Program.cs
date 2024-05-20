using Dev.Plugin.Authen.Infrastructure;
using Dev.Plugin.Blog.Infrastructure;
using Dev.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.AddAuthen();
builder.AddBlog();

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
app.UseAuthen();

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

app.UseAuthen();
app.UseBlog();
app.UseCustomExceptionHandler();
app.Run();

public partial class Program { }
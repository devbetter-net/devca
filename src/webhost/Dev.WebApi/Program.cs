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
string withOrigins = builder.Configuration["AllowedHosts"]!;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        builder.WithOrigins(withOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();
app.UseAuthen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseCors();

app.UseAuthen();
app.UseBlog();

app.MapControllers();
app.Run();

public partial class Program { }
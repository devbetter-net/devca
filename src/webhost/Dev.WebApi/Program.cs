using Dev.Plugin.Authen.Infrastructure;
using Dev.WebApi.Routes;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.AddAuthen();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Routes
WeatherForecastRoutes.RegisterWeatherForecastAPI(app);

app.Run();


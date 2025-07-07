using Microsoft.OpenApi.Models;
using TeaRoundPicker.Services;
using TeaRoundPicker.Services.Cache;
using TeaRoundPicker.Services.Cache.Interfaces;
using TeaRoundPicker.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TeaRoundPicker.Api", Version = "v1" });
});

builder.Services.AddSingleton<ICache, Cache>();
builder.Services.AddTransient<ICacheService, CacheService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TeaRoundPicker.Api v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowReactFrontend");
app.MapControllers();

app.Run();

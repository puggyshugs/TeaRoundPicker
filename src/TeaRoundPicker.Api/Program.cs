using TeaRoundPicker.Services;
using TeaRoundPicker.Services.Cache;
using TeaRoundPicker.Services.Cache.Interfaces;
using TeaRoundPicker.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Register services
builder.Services.AddSingleton<ICache, Cache>();
builder.Services.AddTransient<ICacheService, CacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();


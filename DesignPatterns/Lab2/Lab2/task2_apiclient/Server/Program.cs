using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SomeEntityController>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run("http://localhost:5122");


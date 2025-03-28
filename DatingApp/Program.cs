var builder = WebApplication.CreateBuilder(args);

// Add services to the container. DI

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline. MIDDLEWare


app.MapControllers();

app.Run();

using SensorAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => new HealthService().GetEndpointsUp());

app.Run();

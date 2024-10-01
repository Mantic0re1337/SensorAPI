using Microsoft.EntityFrameworkCore;
using SensorAPI.EFCore;
using SensorAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SensorAPIDbContext>(opt => opt.UseInMemoryDatabase("SensorAPI"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/health", () => new HealthService().GetEndpointsUp());

#region Groups

var moistureSensor = app.MapGroup("/moisture");

#endregion

#region MoistureEndpoints

moistureSensor.MapPost("/{deviceId}", PostforPlant);
#endregion

app.Run();

#region Methods

static async Task<IResult> PostforPlant(Guid deviceId)
{
    throw new NotImplementedException();
}

#endregion
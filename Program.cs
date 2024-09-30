using SensorAPI.Services;

var builder = WebApplication.CreateBuilder(args);
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
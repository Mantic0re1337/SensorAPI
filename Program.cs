using Microsoft.EntityFrameworkCore;
using SensorAPI.Models;
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

moistureSensor.MapPost("/{deviceId}/{value}", PostforPlant);
moistureSensor.MapPost("/addsensor", AddSensor);
#endregion

app.Run();

#region Methods

static async Task<IResult> PostforPlant(int deviceId, int value, SensorAPIDbContext dbContext)
{
    var plant = await dbContext.Plants
    .Where(s => s.SensorId == deviceId).FirstOrDefaultAsync();

    if(plant is null)
        return TypedResults.NotFound();

    plant.WaterLevel = value;
    await dbContext.SaveChangesAsync();
    return TypedResults.Ok();
}

static async Task<IResult> AddSensor(Sensor newSensor, SensorAPIDbContext dbContext)
{
    dbContext.Sensors.Add(newSensor);
    await dbContext.SaveChangesAsync();
    return TypedResults.Created();
}

#endregion
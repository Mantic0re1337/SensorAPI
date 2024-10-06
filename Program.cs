using SensorAPI.Extensions;
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

var sensors = app.MapGroup("/sensors");
var devices = app.MapGroup("/devices");
var plants = app.MapGroup("/plants");


#endregion

#region SensorEndpoints

sensors.MapPost("/add", AddSensor);
sensors.MapDelete("/remove/{id}", RemoveSensor);
sensors.MapPatch("/update/{id}", UpdateSensor);
#endregion

#region DeviceEndpoints
devices.MapPost("/add", AddDevice);
devices.MapDelete("/remove/{id}", RemoveDevice);
devices.MapPatch("/update/{id}", UpdateDevice);

#endregion

#region PlantEndpoints
plants.MapPost("/add", AddPlant);
plants.MapDelete("/remove/{id}", RemovePlant);
plants.MapPatch("/update/{id}", UpdatePlant);
plants.MapGet("/askPlant/{id}", GetWaterLevel);
plants.MapPatch("/updateWater/{id}", UpdateWaterLevel);
#endregion

app.Run();

#region Methods

static async Task<IResult> AddSensor(Sensor newSensor, SensorAPIDbContext dbContext)
{
    dbContext.Sensors.Add(newSensor);
    await dbContext.SaveChangesAsync();
    return TypedResults.Created("/sensors/add", newSensor.Id);
}

static async Task<IResult> RemoveSensor(int id, SensorAPIDbContext dbContext){
    dbContext.Remove(dbContext.Sensors.Single(s => s.Id == id));
    await dbContext.SaveChangesAsync();
    return TypedResults.Ok();
}

static async Task<IResult> UpdateSensor(int id, Sensor update, SensorAPIDbContext dbContext){
    var sensor = dbContext.Sensors.First(s => s.Id == id);
    sensor.UpdateSensorFields(update);
    await dbContext.SaveChangesAsync(); 
    return TypedResults.Accepted($"/sensors/update/{id}");
}

static async Task<IResult> AddDevice(Device newDevice, SensorAPIDbContext dbContext){
    dbContext.Devices.Add(newDevice);
    await dbContext.SaveChangesAsync();
    return TypedResults.Created("/devices/add", newDevice.Id);
}

static async Task<IResult> RemoveDevice(int id, SensorAPIDbContext dbContext){
    dbContext.Remove(dbContext.Devices.Single(d => d.Id == id));
    await dbContext.SaveChangesAsync();
    return TypedResults.Ok();
}

static async Task<IResult> UpdateDevice(int id, Device update, SensorAPIDbContext dbContext){
    var device = dbContext.Devices.First(d=> d.Id == id);
    device.UpdateDeviceFields(update);
    await dbContext.SaveChangesAsync(); 
    return TypedResults.Accepted($"/devices/update/{id}");
}

static async Task<IResult> AddPlant(Plant newPlant, SensorAPIDbContext dbContext){
    dbContext.Plants.Add(newPlant);
    await dbContext.SaveChangesAsync();
    return TypedResults.Created("/plants/add", newPlant.Id);
}

static async Task<IResult> RemovePlant(int id, SensorAPIDbContext dbContext){
    dbContext.Remove(dbContext.Plants.Single(p => p.Id == id));
    await dbContext.SaveChangesAsync();
    return TypedResults.Ok();
}

static async Task<IResult> UpdatePlant(int id, Plant update, SensorAPIDbContext dbContext){
    var plant = dbContext.Plants.First(d=> d.Id == id);
    plant.UpdatePlantFields(update);
    await dbContext.SaveChangesAsync(); 
    return TypedResults.Accepted($"/plant/update/{id}");
}

static async Task<IResult> UpdateWaterLevel(int id, int waterLevel, SensorAPIDbContext dbContext){
    var plant = dbContext.Plants.First(p => p.Id == id);
    plant.WaterLevel = waterLevel;
    await dbContext.SaveChangesAsync();
    return TypedResults.Ok();
}

static IResult GetWaterLevel(int id, SensorAPIDbContext dbContext){
    var plant = dbContext.Plants.First(p => p.Id == id);
    return TypedResults.Ok(plant.WaterLevel); 
}

#endregion
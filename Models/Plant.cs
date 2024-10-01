using System.ComponentModel.DataAnnotations.Schema;

namespace SensorAPI.Models;

public class Plant{
    public Guid Id;
    public string PlantName {get; set;} = "";
    public int WaterLevel {get; set;}
    public bool NeedsWater => WaterLevel > 20;
    public Guid SensorId {get; set;}
    public Sensor? Sensor {get; set;} 
}
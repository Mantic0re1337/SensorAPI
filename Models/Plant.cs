using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SensorAPI.Models;

[PrimaryKey(nameof(Id))]
public class Plant{
    public int Id;
    public string PlantName {get; set;} = "";
    public int WaterLevel {get; set;}
    public bool NeedsWater => WaterLevel > 20;
    public int SensorId {get; set;}
    public Sensor? Sensor {get; set;} 
}
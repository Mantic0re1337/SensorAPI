using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace SensorAPI.Models;

[PrimaryKey(nameof(Id))]
public class Sensor
{
    public int Id {get; set;}
    public SensorType SType {get; set;} 
    public string ModelName {get; set;} = "not specified";
    public Plant? Plant {get; set;}

    public enum SensorType{
        Moisture
    }
}
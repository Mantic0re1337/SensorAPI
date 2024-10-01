using Microsoft.AspNetCore.SignalR;

namespace SensorAPI.Models;

public class Sensor
{
    public Guid Id {get; set;}
    public SensorType SType {get; set;} 
    public string ModelName {get; set;} = "not specified";
    public Guid PlantId {get; set;}
    public Plant? Plant {get; set;}

    public enum SensorType{
        Moisture
    }
}
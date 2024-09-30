namespace SensorAPI.Models;

public class Sensors
{
    public Guid Id {get; set;}
    public SensorType SType {get; set;} 

    public enum SensorType{
        Moisture
    }
}
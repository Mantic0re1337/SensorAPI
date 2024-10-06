using SensorAPI.Models;

namespace SensorAPI.Models;

public class Device{
    public int Id {get; set;}
    public DeviceType DeviceType {get; set;}
    public List<Sensor> AttachedSensors {get; set;} = [];
    public int PlantId {get; set;}
    public Plant? Plant {get; set;}
}

public enum DeviceType{
    Arduino,
    ESP32
}
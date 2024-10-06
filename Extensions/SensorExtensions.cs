using SensorAPI.Models;

namespace SensorAPI.Extensions;

public static class SensorExtensions{
    public static void UpdateSensorFields(this Sensor tobeUpdated, Sensor update){
        tobeUpdated.SType = update.SType;
        tobeUpdated.ModelName = update.ModelName;
        tobeUpdated.DeviceId = update.DeviceId;
    }
}
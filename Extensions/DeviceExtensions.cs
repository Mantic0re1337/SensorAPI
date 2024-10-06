using SensorAPI.Models;

namespace SensorAPI.Extensions;

public static class DeviceExtensions{
    public static void UpdateDeviceFields(this Device tobeUpdated, Device update){
        tobeUpdated.DeviceType = update.DeviceType;
        tobeUpdated.PlantId = update.PlantId;
    }
}
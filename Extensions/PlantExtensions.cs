using SensorAPI.Models;

namespace SensorAPI.Extensions;

public static class PlantExtensions{
    public static void UpdatePlantFields(this Plant tobeUpdated, Plant update){
        tobeUpdated.PlantName = update.PlantName;
        tobeUpdated.WaterLevel = update.WaterLevel;
    }
}
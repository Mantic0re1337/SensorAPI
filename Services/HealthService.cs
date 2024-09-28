using SensorAPI.Models;
using SensorAPI.Services;

namespace SensorAPI.Services;

public class HealthService{
    public int GetEndpointsUp(){
        return APIHealthState.EndpointsUp;
    }
}
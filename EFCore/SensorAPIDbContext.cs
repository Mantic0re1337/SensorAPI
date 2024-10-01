using Microsoft.EntityFrameworkCore;
using SensorAPI.Models;

namespace SensorAPI.EFCore;

public class SensorAPIDbContext : DbContext{
    public SensorAPIDbContext(DbContextOptions<SensorAPIDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<Plant> Plants => Set<Plant>(); 
}
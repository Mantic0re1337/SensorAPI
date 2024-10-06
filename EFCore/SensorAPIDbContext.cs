using Microsoft.EntityFrameworkCore;
using SensorAPI.Models;

namespace SensorAPI.EFCore;

public class SensorAPIDbContext : DbContext{
    public SensorAPIDbContext(DbContextOptions<SensorAPIDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<Device> Devices => Set<Device>();
    public DbSet<Plant> Plants => Set<Plant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sensor>()
            .HasOne(s => s.Device)
            .WithMany(d => d.AttachedSensors)
            .HasForeignKey(s => s.DeviceId)
            .IsRequired(false);

        modelBuilder.Entity<Device>()
            .HasOne(p => p.Plant)
            .WithMany(p => p.Devices)
            .HasForeignKey(s => s.PlantId)
            .IsRequired(false);
    }
}
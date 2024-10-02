using Microsoft.EntityFrameworkCore;
using SensorAPI.Models;

namespace SensorAPI.EFCore;

public class SensorAPIDbContext : DbContext{
    public SensorAPIDbContext(DbContextOptions<SensorAPIDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<Plant> Plants => Set<Plant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sensor>()
            .HasOne(s => s.Plant)
            .WithOne(s => s.Sensor)
            .HasForeignKey<Plant>(s => s.SensorId)
            .IsRequired();

        modelBuilder.Entity<Plant>()
            .HasOne(p => p.Sensor)
            .WithOne(p => p.Plant)
            .HasForeignKey<Plant>(s => s.SensorId)
            .IsRequired();
    }
}
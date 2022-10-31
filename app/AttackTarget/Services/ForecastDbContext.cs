using Microsoft.EntityFrameworkCore;

namespace AttackTarget.Services;

public class ForecastDbContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public ForecastDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().ToTable("Forecasts");
        modelBuilder.Entity<WeatherForecast>().HasKey(wf => wf.Id).HasName("PK_Forecasts");
        modelBuilder.Entity<WeatherForecast>().HasIndex(wf => wf.Date).HasDatabaseName("Idx_ForecastDate");
        modelBuilder.Entity<WeatherForecast>().Property(wf => wf.Summary).HasColumnType("nvarchar(500)").IsRequired();
    }
}
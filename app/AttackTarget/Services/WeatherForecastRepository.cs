using Microsoft.EntityFrameworkCore;

namespace AttackTarget.Services;
public class WeatherForecastRepository
{
    private readonly ForecastDbContext dbContext;

    public WeatherForecastRepository(ForecastDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync()
    {
        var forecasts = await dbContext.WeatherForecasts.ToListAsync();
        return forecasts;
    }

    public async Task<WeatherForecast?> GetAsync(int id)
    {
        var forecast = await dbContext.WeatherForecasts.FirstOrDefaultAsync(wf => wf.Id == id);
        return forecast;
    }

    public async Task<int> AddAsync(WeatherForecast forecast)
    {
        var res = await dbContext.WeatherForecasts.AddAsync(forecast);
        await dbContext.SaveChangesAsync();

        return res.Entity.Id;
    }
}

using AttackTarget.Services;
using Microsoft.AspNetCore.Mvc;

namespace AttackTarget.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherForecastRepository _repository;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("/")]
    public async Task<IActionResult> GetAsync()
    {
        var forecasts = await _repository.GetAllAsync();
        Thread.Sleep(2500);
        return Ok(forecasts);
    }

    [HttpGet]
    [Route("/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
    {
        var forecast = await _repository.GetAsync(id);
        return Ok(forecast);
    }

    [HttpPost(Name = "AddWeatherForecast")]
    public async Task<IActionResult> AddAsync(WeatherForecast forecast)
    {
        forecast.Id = await _repository.AddAsync(forecast);
        return Ok(forecast);
    }

    [HttpPost(Name = "ProcessWeatherForecast")]
    public async Task<IActionResult> ProcessAsync()
    {
        var forecasts = await _repository.GetAllAsync();

        Thread.Sleep(2500);

        return Ok(forecasts);
    }
}

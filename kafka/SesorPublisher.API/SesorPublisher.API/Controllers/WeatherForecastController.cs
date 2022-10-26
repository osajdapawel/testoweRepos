using Microsoft.AspNetCore.Mvc;

namespace SesorPublisher.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherDataPublisher _dataPublisher;

        public WeatherForecastController(IWeatherDataPublisher dataPublisher)
        {
            _dataPublisher = dataPublisher;
        }

        [HttpPost]
        public async void Post([FromBody] Weather weather)
        {
            await _dataPublisher.ProduceAsync(weather);
        }
    }
}
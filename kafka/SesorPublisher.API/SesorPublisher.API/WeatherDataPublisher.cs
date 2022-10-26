using Confluent.Kafka;
using Newtonsoft.Json;

namespace SesorPublisher.API
{
    public class WeatherDataPublisher : IWeatherDataPublisher
    {
        private readonly IProducer<Null, string> _producer;

        public WeatherDataPublisher(IProducer<Null, string> producer)
        {
            _producer = producer;
        }

        public async Task ProduceAsync(Weather weather)
        {
           var response = await _producer.ProduceAsync("weather-topic", new Message<Null, string> { Value = JsonConvert.SerializeObject(weather) });
            Console.WriteLine(response.Value);
        }
    }

    public record Weather(string state, int temp);
}
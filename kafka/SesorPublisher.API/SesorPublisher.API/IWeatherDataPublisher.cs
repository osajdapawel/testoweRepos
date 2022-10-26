namespace SesorPublisher.API
{
    public interface IWeatherDataPublisher
    {
        public Task ProduceAsync(Weather weather);
    }
}

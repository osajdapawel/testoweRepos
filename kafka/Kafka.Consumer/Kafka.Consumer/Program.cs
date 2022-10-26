﻿using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ConsumerConfig
{
    GroupId = "weather-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, string>(config).Build();

consumer.Subscribe("weather-topic");
CancellationTokenSource token = new();

try
{
    while(true)
    {
        var response = consumer.Consume(token.Token);
        if(response.Message != null)
        {
            var weather = JsonConvert.DeserializeObject<Weather>(response.Message.Value);
            Console.WriteLine($"State: {weather.state}, temp: {weather.temp}");
        }
    }
}
catch (Exception ex)
{
    throw;
}

public record Weather(string state, int temp);

using System;
using System.Configuration;
using LocalExplorer.Models;
using Newtonsoft.Json;

namespace LocalExplorer.Services
{

    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherApiResponse> GetWeatherAsync(string city)
        {
            var apiKey = _configuration["WeatherApi:ApiKey"];
            var response = await _httpClient.GetStringAsync($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=yes");
            return JsonConvert.DeserializeObject<WeatherApiResponse>(response);
        }
    }


}


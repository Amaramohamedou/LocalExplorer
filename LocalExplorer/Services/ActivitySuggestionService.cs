using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LocalExplorer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LocalExplorer.Services
{
    public class ActivitySuggestionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiApiKey;
        private readonly string _weatherApiKey;

        public ActivitySuggestionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _openAiApiKey = configuration["OpenAI:OpenAIKey"];
            //_weatherApiKey = configuration["WeatherAPI:ApiKey"];
        }

        private HttpRequestMessage CreateRequestMessage(string city, string weather, string localtime, string tempC, string status)
        {
            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = "You are a helpful assistant."
                    },
                    new
                    {
                        role = "user",
                        content = $"I feel so much bored, I need something to do. My city: {city}, my weather is {weather}, " +
                                  $"today's date & time: {localtime}, and the temperature is: {tempC} C. " +
                                  $"I want you to give me 5 {status} activity suggestions (one-line text) each with a title or topic given by you. " +
                                  "Separate the activity and its title with ':'. Separate each activity suggestion with ';'. " +
                                  "Do not use '\\n' or new lines; keep all in one line. " +
                                  "I want your answers to be unique, decorated with emojis, and detailed."
                    }
                },
                max_tokens = 3000,
                temperature = 1
            };

            var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
            {
                Content = requestContent
            };
            requestMessage.Headers.Add("Authorization", $"Bearer {_openAiApiKey}");

            return requestMessage;
        }

        public async Task<Suggestions> GetActivitySuggestionsAsync(string city, string weather, string localtime, string tempC, string status)
        {
            int delay = 1000;
            var requestMessage = CreateRequestMessage(city, weather, localtime, tempC, status);
            var response = await _httpClient.SendAsync(requestMessage);

            while (response.StatusCode == (HttpStatusCode)429)
            {
                await Task.Delay(delay);
                delay *= 2;
                response = await _httpClient.SendAsync(requestMessage);
            }

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Suggestions>(responseString);
        }




    }
}


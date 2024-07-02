
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalExplorer.Services;
using LocalExplorer.Models;

namespace LocalExplorer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalExplorerController : ControllerBase
    {
        private readonly IpInfoService _ipInfoService;
        private readonly WeatherService _weatherService;
        private readonly ActivitySuggestionService _activitySuggestionService;

        public LocalExplorerController(IpInfoService ipInfoService, WeatherService weatherService, ActivitySuggestionService activitySuggestionService)
        {
            _ipInfoService = ipInfoService;
            _weatherService = weatherService;
            _activitySuggestionService = activitySuggestionService;
        }


        [HttpGet("suggestions")]
        public async Task<IActionResult> GetSuggestions()
        {
            var ipInfo = await _ipInfoService.GetIpInfoAsync();
            var weather = await _weatherService.GetWeatherAsync(ipInfo.City);

            string city = ipInfo.City;
            string weatherText = weather.Current.Condition.Text;
            string localtime = weather.Location.Localtime;
            string tempC = weather.Current.TempC.ToString();
            string icon = weather.Current.Condition.Icon;
            string status = "outdoor";

            var suggestions = await _activitySuggestionService.GetActivitySuggestionsAsync(city, weatherText, localtime, icon, tempC, status);

            if (suggestions == null)
            {
                return Ok(new
                {
                    suggestions = new Suggestions(),
                    city = city,
                    weather = weatherText,
                    localtime = localtime,
                    icon = icon,
                    tempC = tempC,
                    status = status
                });
            }

            return Ok(new
            {
                suggestions = suggestions,
                city = city,
                weather = weatherText,
                localtime = localtime,
                icon = icon,
                tempC = tempC,
                status = status
            });
        }




    }
}

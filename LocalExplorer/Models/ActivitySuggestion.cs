using System;
namespace LocalExplorer.Models
{
    public class ActivitySuggestion
    {
            public Suggestions Suggestions { get; set; }
            public string City { get; set; }
            public string Weather { get; set; }
            public string LocalTime { get; set; }
            public string TempC { get; set; }
            public string Status { get; set; }

            public ActivitySuggestion(Suggestions suggestions, string city, string weather, string localtime, string tempC, string status)
            {
                Suggestions = suggestions;
                City = city;
                Weather = weather;
                LocalTime = localtime;
                TempC = tempC;
                Status = status;
            }

        }


    
}


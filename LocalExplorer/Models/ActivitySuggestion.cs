using System;
namespace LocalExplorer.Models
{
    public class ActivitySuggestion
    {
        //public String suggestions { get; set; }
        //public String city { get; set; }
        //public String weather { get; set; }
        //public String localtime { get; set; }
        //public String tempC { get; set; }
        //public String status { get; set; }


        //public ActivitySuggestion(String suggestions, String city, String weather, String localtime, String tempC, String status)
        //{
        //    this.suggestions = suggestions;
        //    this.city = city;
        //    this.weather = weather;
        //    this.localtime = localtime;
        //    this.tempC = tempC;
        //    this.status = status;
        //}


  
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


using Newtonsoft.Json;

public class WeatherApiResponse
{
    public Location Location { get; set; }
    public Current Current { get; set; }
}

public class Location
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("region")]
    public string Region { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("lon")]
    public double Lon { get; set; }

    [JsonProperty("tz_id")]
    public string TzId { get; set; }

    [JsonProperty("localtime_epoch")]
    public long LocaltimeEpoch { get; set; }

    [JsonProperty("localtime")]
    public string Localtime { get; set; }
}

public class Current
{
    [JsonProperty("last_updated_epoch")]
    public long LastUpdatedEpoch { get; set; }

    [JsonProperty("last_updated")]
    public string LastUpdated { get; set; }

    [JsonProperty("temp_c")]
    public double TempC { get; set; }

    [JsonProperty("temp_f")]
    public double TempF { get; set; }

    [JsonProperty("is_day")]
    public int IsDay { get; set; }

    [JsonProperty("condition")]
    public Condition Condition { get; set; }

    [JsonProperty("wind_mph")]
    public double WindMph { get; set; }

    [JsonProperty("wind_kph")]
    public double WindKph { get; set; }

    [JsonProperty("wind_degree")]
    public int WindDegree { get; set; }

    [JsonProperty("wind_dir")]
    public string WindDir { get; set; }

    [JsonProperty("pressure_mb")]
    public double PressureMb { get; set; }

    [JsonProperty("pressure_in")]
    public double PressureIn { get; set; }

    [JsonProperty("precip_mm")]
    public double PrecipMm { get; set; }

    [JsonProperty("precip_in")]
    public double PrecipIn { get; set; }

    [JsonProperty("humidity")]
    public int Humidity { get; set; }

    [JsonProperty("cloud")]
    public int Cloud { get; set; }

    [JsonProperty("feelslike_c")]
    public double FeelslikeC { get; set; }

    [JsonProperty("feelslike_f")]
    public double FeelslikeF { get; set; }

    [JsonProperty("windchill_c")]
    public double WindchillC { get; set; }

    [JsonProperty("windchill_f")]
    public double WindchillF { get; set; }

    [JsonProperty("heatindex_c")]
    public double HeatindexC { get; set; }

    [JsonProperty("heatindex_f")]
    public double HeatindexF { get; set; }

    [JsonProperty("dewpoint_c")]
    public double DewpointC { get; set; }

    [JsonProperty("dewpoint_f")]
    public double DewpointF { get; set; }

    [JsonProperty("vis_km")]
    public double VisKm { get; set; }

    [JsonProperty("vis_miles")]
    public double VisMiles { get; set; }

    [JsonProperty("uv")]
    public double Uv { get; set; }

    [JsonProperty("gust_mph")]
    public double GustMph { get; set; }

    [JsonProperty("gust_kph")]
    public double GustKph { get; set; }

    [JsonProperty("air_quality")]
    public AirQuality AirQuality { get; set; }
}

public class Condition
{
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }

    [JsonProperty("code")]
    public int Code { get; set; }
}

public class AirQuality
{
    [JsonProperty("co")]
    public double Co { get; set; }

    [JsonProperty("no2")]
    public double No2 { get; set; }

    [JsonProperty("o3")]
    public double O3 { get; set; }

    [JsonProperty("so2")]
    public double So2 { get; set; }

    [JsonProperty("pm2_5")]
    public double Pm25 { get; set; }

    [JsonProperty("pm10")]
    public double Pm10 { get; set; }

    [JsonProperty("us-epa-index")]
    public int UsEpaIndex { get; set; }

    [JsonProperty("gb-defra-index")]
    public int GbDefraIndex { get; set; }
}


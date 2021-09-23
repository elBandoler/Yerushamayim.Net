using System.Text.Json.Serialization;

namespace Yerushamayim.Net
{
    public class WeatherData
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }
        /// <summary>
        /// The actual temperature ("on the mountain")
        /// </summary>
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        /// <summary>
        /// What temperature it feels like ("in the valley")
        /// </summary>
        [JsonPropertyName("temp2")]
        public string TempFeelsLike { get; set; }
        /// <summary>
        /// the Temperature on the road
        /// </summary>
        [JsonPropertyName("temp3")]
        public string TempOnRoad { get; set; }
        [JsonPropertyName("hum")]
        public string Humidity { get; set; }
        [JsonPropertyName("pressure")]
        public string Pressure { get; set; }
        [JsonPropertyName("winddir")]
        public string WindDirection { get; set; }
        [JsonPropertyName("windspd")]
        public int WindSpeed { get; set; }
        [JsonPropertyName("rainrate")]
        public string RainRate { get; set; }
        [JsonPropertyName("rainchance")]
        public int RainChance { get; set; }
        [JsonPropertyName("solarradiation")]
        public string SolarRadiation { get; set; }
        [JsonPropertyName("sunshinehours")]
        public double SunshineHours { get; set; }
        [JsonPropertyName("rain")]
        public string RainToday { get; set; }
    }
}

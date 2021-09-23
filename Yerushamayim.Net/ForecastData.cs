using System.Text.Json.Serialization;

namespace Yerushamayim.Net
{
    public class ForecastData
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("day_name")]
        public string DayName { get; set; }
        [JsonPropertyName("lang0")]
        public string SummaryEnglish { get; set; }
        [JsonPropertyName("lang1")]
        public string SummaryHebrew { get; set; }
        public string TempLow { get; set; }
        public string TempHigh { get; set; }
        public string TempNight { get; set; }
        [JsonPropertyName("humDay")]
        public string HumidityDay { get; set; }
    }
}

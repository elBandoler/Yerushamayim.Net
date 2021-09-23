using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;

namespace Yerushamayim.Net
{
    public class YN
    {
        /// <summary>
        /// The API endpoint of 02ws
        /// </summary>
        const string APIEndpoint = "https://www.02ws.co.il/services";

        /// <summary>
        /// The currently used temperature unit (Celsius or Farenheit)
        /// </summary>
        static TemperatureUnit TemperatureUnit = TemperatureUnit.C;

        /// <summary>
        /// Allows the developer to set the app's temperature unit to either Celsius (default) or Farenheit
        /// </summary>
        public static void SetDegreeUnit(TemperatureUnit temperatureUnit)
            => TemperatureUnit = temperatureUnit;

        /// <summary>
        /// Gets a WeatherData object containing the current weather
        /// </summary>
        /// <returns>a WeatherData object</returns>
        public static async Task<WeatherData> GetCurrentWeatherAsync()
        {
            string query = $"{APIEndpoint}/now/0/1/{TemperatureUnit}/1";
            // The following is not an elegant solution, but it is practical, since the 02ws API returns a malformed Json.
            string json = $"[{{{(await Query(query)).Replace('[',' ').Replace(']',' ').Replace('{',' ').Replace('}',' ')}}}]";
            return JsonSerializer.Deserialize<WeatherData[]>(json)[0];
        }

        /// <summary>
        /// Gets the forecast entry for the specified day.
        /// </summary>
        /// <param name="day">A ForecastDay value</param>
        /// <returns>A ForecastData object, or null.</returns>
        public static ForecastData GetForecastForDay(ForecastDay day)
        {
            string query = $"{APIEndpoint}/forecast/{day}/1/{TemperatureUnit}/1";
            return JsonSerializer.Deserialize<ForecastData>(Query(query).Result);
        }

        /// <summary>
        /// Gets the forecast for all available days
        /// </summary>
        /// <returns>An ICollection of ForecastData objects</returns>
        public static ICollection<ForecastData> GetFullForecast()
        {
            string query = $"{APIEndpoint}/forecast/0/1/{TemperatureUnit}/1";
            return JsonSerializer.Deserialize<ICollection<ForecastData>>(Query(query).Result);
        }

        /// <summary>
        /// Executes the query and returns its result
        /// </summary>
        /// <returns>The result as a string</returns>
        private static async Task<string> Query(string query)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                var response = await httpClient.GetAsync(query);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
    }
}

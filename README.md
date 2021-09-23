# 🌤 Yerushamayim.Net
Yerushamayim.Net is a wrapper library for the 02ws (ירושמיים) API.<br>
**Disclaimer:** This wrapper is **in no way** related to or endorsed by 02ws, nor was it made by them or anyone related to them.<br>
It is **only** meant to allow simpler access to their API for C# developers.<br>
All of the data gathered using this wrapper is owned by its respective owners, using APIs the owner made available to the public.

## What is 02ws - ירושמיים?
02ws - ירושמיים (Yerushamayim) is a Jerusalem-based weather <a href="https://02ws.co.il">website</a><br>
The site was created in 2002 by Boaz Nehemia, a weather enthusiast who owns a local weather station.<br>
02ws also provides an app and a public API.

## How do I use this API?
There are four functions you should care about. <br>
### `SetTemperatureUnit`<br>
It receives a `TemperatureUnit` as its only parameter.<br>
Use it to change the unit from Celsius to Farenheit and vice-versa.<br>
Note that if you want to use Celsius as your main scale, it is the default value.

### `GetCurrentWeatherAsync`
It has no parameters.<br>
Use it to get the current weather as a WeatherData object.

### `GetForecastForDayAsync`
It receives a `ForecastDay` - that is, an enum representing the days of the week as 02ws understands them.<br>
Use it to get the forecast for that day, as a ForecastData object.

### `GetFullForecastAsync`
It receives no parameters.<br>
Use it to get the forecast for that day, as an ICollection of type ForecastData.

## Example

```cs
WeatherData wd = GetCurrentWeatherAsync();
Console.WriteLine($"Current temperature: {wd.Temp}");
Console.WriteLine($"Actual feeling: {wd.TempFeelsLike}");
Console.WriteLine($"Last updated at {wd.Time}");

ForecastData fd = GetForecastForDayAsync(ForecastDay.Today);
Console.WriteLine($"Max temperature today: {fd.TempHigh}");
```

## Additional notes
- Use the API with respect - don't repeat queries unnecessarily, cache the data instead.

using Newtonsoft.Json;

namespace Weather_TG
{
    class ParsingWebsite
    {
        public static Weather? ReadWeather(string namecity)
        {
            string cityKey = SearchCity.SearchID(namecity);

            string URL = $"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{cityKey}?apikey={ApplicationSettings.APIKeyWeather}&language=ru&metric=true";

            string responseBody = ReadJson(URL);

            var weather_reponse = JsonConvert.DeserializeObject<RootWeather>(responseBody);

            if(weather_reponse != null)
            {
                DailyForecast weather = weather_reponse.DailyForecasts.First();
                var result = new Weather(weather.Day.IconPhrase, weather.Night.IconPhrase, DateTime.Now, weather.Temperature.Minimum.Value, weather.Temperature.Maximum.Value, weather.Day.Icon);
            }


            return null;
        }

        public static string ReadJson(string URL)
        {
            using HttpClient httpClient = new HttpClient();

            HttpRequestMessage _request = new HttpRequestMessage(HttpMethod.Get, URL);

            var _response = httpClient.Send(_request);

            using var reader = new StreamReader(_response.Content.ReadAsStream());

            return reader.ReadToEnd();
        }
    }
}

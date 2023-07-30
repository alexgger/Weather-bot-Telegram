using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Weather_TG
{
    class SearchCity : TelegramBot
    {
        /// <summary>
        /// Поиск ID города по названию
        /// </summary>
        public static string SearchID(string name)
        {
            string URL = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={ApplicationSettings.APIKeyWeather}&q={name}";

            string response = ParsingWebsite.ReadJson(URL);

            var cities = JsonConvert.DeserializeObject<ObservableCollection<CityId>>(response);

            if (cities == null) return "no";

            return cities.First().Key;
        }
    }
}

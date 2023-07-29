namespace Weather_TG
{
    class Weather
    {
        private string NameDay { get; set; }
        private string NameNigth { get; set; }
        private DateTime Date { get; set; }
        private double Minimal { get; set; }
        private double Maximal { get; set; }
        public string IconWeather { get; set; }

        public Weather(string nameday, string namenight, DateTime date, double minimal, double maximal, string iconWeather)
        {
            NameDay = nameday;
            NameNigth = namenight;
            Date = date;
            Minimal = minimal;
            Maximal = maximal;
            IconWeather = iconWeather;
        }

        /// <summary>
        /// Отображение погоды
        /// </summary>
        public string ShowInfo()
        {
            return $"{Date.DayOfWeek} | Дата: {Date.ToShortDateString()} | \n\nДнем: {NameDay}\nНочью: {NameNigth}\nМин. температура {Minimal}, Макс. температура: {Maximal}\n";
        }

        /// <summary>
        /// Подгрузка иконок погоды. Изначально на сайте accuweather.com картинки были представлены в SVG-формате. Телеграмм бот не отсылает такие изображения, соотвественно пришлось конвертировать и заливать на свой сайт
        /// </summary>
        public string SendIcon()
        {
            return $"https://alexgger.ru/iconWeather/{IconWeather}.jpg";
        }
    }
}

﻿namespace Weather_TG
{

    public class CityId
    {
        public string Key { get; set; } = string.Empty;
        public string LocalizedName { get; set; } = string.Empty;
    }


    class DailyForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }

    }

    public class Day
    {
        public string Icon { get; set; } = string.Empty;
        public string IconPhrase { get; set; } = string.Empty;
    }

    public class Night
    {
        public string Icon { get; set; } = string.Empty;
        public string IconPhrase { get; set; } = string.Empty;
    }


    public class Minimum
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }

    public class Maximum
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }


    class RootWeather
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

}

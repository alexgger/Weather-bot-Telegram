﻿namespace Weather_TG
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            // www.accuweather.com - 50 API calls per day

            Console.Title = ApplicationSettings.NameApplication;

            TelegramBot bot = new TelegramBot();
            bot.WorkBot();
        }
    }  
}


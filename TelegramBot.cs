using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace Weather_TG
{
    class TelegramBot
    {
        private static TelegramBotClient client;

        /// <summary>
        /// Запуск телеграмм бота
        /// </summary>
        public void WorkBot()
        {
                client = new TelegramBotClient(ApplicationSettings.APIKeyTelegram);
                client.StartReceiving(
                    updateHandler: OnMessageHandler,
                    pollingErrorHandler: HandlePollingErrorAsync);
            Console.ReadKey();

        }

        /// <summary>
        /// Обработка приходящих сообщений 
        /// </summary>
        async Task OnMessageHandler(object sender, Update update, CancellationToken cancellationToken)
        {
            var msg = update.Message;

            try
            {
                if (msg.Text != null || msg.Text != "")
                {
                    if(msg.Text == "/start")
                    {
                        await client.SendTextMessageAsync(msg.Chat.Id, "Привет! Я телеграмм бот, который покажет тебе актуальную погоду на необходимый указанный промежуток времени! Ну, что? Начнем?");
                    }
                    else
                    {
                        var IDcity = SearchCity.SearchID(msg.Text.ToLower());

                        if (IDcity != "no")
                        {
                            var weather = ParsingWebsite.ReadWeather(IDcity);

                            await client.SendTextMessageAsync(msg.Chat.Id, weather.ShowInfo());
                            await client.SendPhotoAsync(msg.Chat.Id, InputFile.FromString(weather.SendIcon()));
                        }
                        else
                        {
                            await client.SendTextMessageAsync(msg.Chat.Id, "К сожалению, я не смог найти этот город :(");
                        }
                    }

                }
            }
            catch { Console.WriteLine("OnMessageHandler | Произошла ошибка! (или закончились API calls) | " + msg.Text); }


        }


        /// <summary>
        /// Обработка исключений (взято с telegrambots.github.io)
        /// </summary>
        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}

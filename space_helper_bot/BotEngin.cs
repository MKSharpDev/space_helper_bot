using space_helper_bot.NasaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace space_helper_bot
{
    public class BotEngin
    {
        private readonly TelegramBotClient _botClient;

        public BotEngin(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task DailyTaskAsync()
        {
            while (true)
            {
                using var cts = new CancellationTokenSource();

                try
                {


                    string urlString = "https://api.telegram.org/bot{0}/sendPhoto?chat_id={1}&caption={2}&photo={3}";
                    ShowNasaAPI NASA = new ShowNasaAPI("https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date=2023-04-10");

                    string apiToken = AccesToken.Value.ToString();
                    string chatId = "@kosmos_future";
                    string text = NASA.Response.Explanation;
                    string photo = NASA.Response.Url;
                    urlString = String.Format(urlString, apiToken, chatId, text, photo);
                    WebRequest request = WebRequest.Create(urlString);
                    Stream rs = request.GetResponse().GetResponseStream();
                    StreamReader reader = new StreamReader(rs);
                    string line = "";
                    StringBuilder sb = new StringBuilder();


                    Thread.Sleep(10000);



                }
                catch (Exception)
                {


                }

                cts.Cancel();
                while (!cts.Token.IsCancellationRequested)
                {
                    Thread.Sleep(10000);
                };
            }
        }
   

        




    }

}

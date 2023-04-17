using space_helper_bot.NasaAPI;
using space_helper_bot.TranslateAPI;
using space_helper_bot.TranslateSelenium;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        

        public BotEngin( )
        {
           
        }

        public async Task DailyTaskAsync()
        {
            //while (true)
            //{
 

                try
                {

                    await GetNASAImage();
                    

                    



                }
                catch (Exception)
                {


                }

 
            //}
        }
        public async Task GetNASAImage()
        {

            string urlPhoto = "https://api.telegram.org/bot{0}/sendPhoto?chat_id={1}&caption={2}&photo={3}";
            string urlMassage = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string NasaToken = AccesToken.NasaToken;
            ShowNasaAPI NASA = new ShowNasaAPI($"https://api.nasa.gov/planetary/apod?api_key={NasaToken}&date={date}");
            await Task.Delay(1000);
            string apiToken = AccesToken.TelegramToken;
            string chatId = "@kosmos_future";

            SeleniumTranslate translateAPI = new SeleniumTranslate();
            string titleEn = NASA.Response.Title;
            var title = translateAPI.GetTranslate(titleEn).Result;
            string textEn = NASA.Response.Explanation;            
            var text = translateAPI.GetTranslate(textEn).Result;
            await Task.Delay(15000);

            if (title.Length >= 1000)
            {
                title = title.Split('.').First().ToString();
            }
            await Task.Delay(15000);
            string photo = NASA.Response.Url;
            urlPhoto = String.Format(urlPhoto, apiToken, chatId, title, photo);
            urlMassage = String.Format(urlMassage, apiToken, chatId, text);
            try
            {
                WebRequest requestPhoto = WebRequest.Create(urlPhoto);
                await Task.Delay(1000);
                WebRequest requestMassage = WebRequest.Create(urlMassage);
                await Task.Delay(1000);
                Stream rs1 = requestPhoto.GetResponse().GetResponseStream();
                Stream rs2 = requestMassage.GetResponse().GetResponseStream();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in telegramm photo request {ex} . {ex.Message}");
            }
            try
            {

            }
            catch (Exception exText)
            {

                Console.WriteLine($"Error in telegramm photo request {exText}. {exText.Message}");
                
            }








            //StreamReader reader = new StreamReader(rs1);
            //StringBuilder sb = new StringBuilder();


        }
    }

}

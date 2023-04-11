
using Telegram.Bot;
using space_helper_bot;
using System.Net;
using System.Text;
using space_helper_bot.NasaAPI;

string urlString = "https://api.telegram.org/bot{0}/sendPhoto?chat_id={1}&caption={2}&photo={3}";
ShowNasaAPI NASA =  new ShowNasaAPI("https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date=2023-04-10");

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





//await SpaceBot.ListenForMassageAsync();
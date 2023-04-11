using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Authenticators;


namespace space_helper_bot.TranslateAPI
{
    public class LingvanexAPI
    {

        public async Task<string> GetTranslate(string inputData)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://text-translator2.p.rapidapi.com/translate"),
                Headers =
            {
                { "X-RapidAPI-Key", "84a9e32438mshb1c4e9b3156ff65p13f0e8jsna9649a2cb06b" },
                { "X-RapidAPI-Host", "text-translator2.p.rapidapi.com" },
            },
                        Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "source_language", "en" },
                { "target_language", "ru" },
                { "text", "inputData" },
            }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
           
        }
    }
}

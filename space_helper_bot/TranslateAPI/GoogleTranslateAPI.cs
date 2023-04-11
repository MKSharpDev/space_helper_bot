using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_helper_bot.TranslateAPI
{
    public class GoogleTranslateAPI
    {
        public async Task<string> GetTranslate(string inputData)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
            {
                { "X-RapidAPI-Key", "84a9e32438mshb1c4e9b3156ff65p13f0e8jsna9649a2cb06b" },
                { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
            },
                        Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "q", $"{inputData}" },
                { "target", "de" },
                { "source", "en" },
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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace space_helper_bot.NasaAPI
{
    public class ShowNasaAPI
    {
        
        public NasaItems Response { get; set; }


        public ShowNasaAPI(string url)
        {
             this.Response = ReturnJSON(url);
        }

        NasaItems ReturnJSON(string url)
        {
            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            string _rezult;

            using (StreamReader str = new StreamReader(response.GetResponseStream()))
            {
                _rezult = str.ReadToEnd();
            }

            NasaItems rezult = JsonConvert.DeserializeObject<NasaItems>(_rezult);
            return rezult;
        }
    }
}

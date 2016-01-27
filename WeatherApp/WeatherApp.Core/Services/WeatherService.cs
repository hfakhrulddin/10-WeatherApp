using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Domain;

namespace WeatherApp.Core.Services
{
    public class WeatherService
    {
        static string apiKey = "7143eb24e47769b4";

        public static ConditionsResult GetWeatherFor(string zipCode)
        {
            using (WebClient wc = new WebClient())
            {
               
                string json = wc.DownloadString($"http://api.wunderground.com/api/{apiKey}/conditions/q/CA/{zipCode}.json");

                var result = JsonConvert.DeserializeObject<ConditionsResult>(JObject.Parse(json)["current_observation"].ToString());

                return result;
            }


        }
    }
}

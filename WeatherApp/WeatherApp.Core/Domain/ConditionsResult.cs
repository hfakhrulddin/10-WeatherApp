using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Domain
{
    public class ConditionsResult
    {
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string weather { get; set; }
        public float temp_f { get; set; }
        public string temp_c { get; set; }
        public string feelslike_string { get; set; }
        public string observation_time { get; set; }
        public decimal visibility_mi { get; set; }
        public decimal UV { get; set; }
        public string relative_humidity { get; set; }
        public string precip_today_string { get; set; }
        public string wind_dir { get; set; }
        public string wind_string { get; set; }
        public ConditionsResult2 display_location { get; set; }




        public class ConditionsResult2
        {
            public string full { get; set; }
            public decimal latitude { get; set; }
            public decimal longitude { get; set; }
            public decimal elevation { get; set; }
        }

    }
}

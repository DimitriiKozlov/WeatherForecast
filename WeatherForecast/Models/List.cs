using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherForecast.Models
{
    public class List
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public System.DateTime DtTxt { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("snow")]
        public Rain Snow { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("coord")]
        public Coord Coord { get; set; }
    }
}
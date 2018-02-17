// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using WeatherForecast.Models;
//
//    var data = WeatherModel.FromJson(jsonString);

namespace WeatherForecast.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class WeatherModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("list")]
        public List<List> List { get; set; }
    }


    public partial class WeatherModel
    {
        public static WeatherModel FromJson(string json) => JsonConvert.DeserializeObject<WeatherModel>(json, Converter.Settings);
    }
}

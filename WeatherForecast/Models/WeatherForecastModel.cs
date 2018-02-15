using System.Collections.Generic;

namespace WeatherForecast.Models
{
    public class WeatherForecastModel
    {
        public string Cod { get; set; }
        public double Message { get; set; }
        public long Cnt { get; set; }
        public List<List> List { get; set; }
        public City City { get; set; }
    }

    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class List
    {
        public long Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public System.DateTime DtTxt { get; set; }
        public Rain Rain { get; set; }
        public Rain Snow { get; set; }
    }

    public class Clouds
    {
        public long All { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double Pressure { get; set; }
        public double SeaLevel { get; set; }
        public double GrndLevel { get; set; }
        public long Humidity { get; set; }
        public double TempKf { get; set; }
    }

    public class Rain
    {
        public double? The3H { get; set; }
    }

    public class Sys
    {
        public string Pod { get; set; }
    }

    public class Weather
    {
        public long Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
    }
}
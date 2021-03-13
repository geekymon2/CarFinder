using System.Text.Json.Serialization;

namespace GeekyMon2.CarsApi.Models
{
    public class Car
    {
        public string ID {get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BodyType BodyType { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Transmission Transmission { get; set; }  
    }
}
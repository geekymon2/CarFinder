using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GeekyMon2.CarsApi.Models
{
    public class Car
    {
        public Car()
        {}

        public Car(string id)
        {
            ID = id;            
        }

        public string ID {get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column(TypeName = "nvarchar(128)")]
        public BodyType BodyType { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column(TypeName = "nvarchar(128)")]
        public Transmission Transmission { get; set; }

        public override string ToString() {
            return string.Format("Car: id={0}, make={1}, model={2}, year={3} ", ID, Make, Model, Year);
         }
    }
}
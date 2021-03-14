using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GeekyMon2.CarsApi.DataAccess.Entities
{
    public class Car
    {
        public Car()
        {}

        public Car(string id)
        {
            ID = id;            
        }

        public Car(string id, string make, string model, int year, int doors, string bodyType, string transmission)
        {
            ID = id;            
            Make = make;
            Model = model;
            Year = year;
            Doors = doors;
            BodyType = (BodyType)System.Enum.Parse(typeof(BodyType),bodyType);
            Transmission = (Transmission)System.Enum.Parse(typeof(Transmission),transmission);
        }

        public string ID {get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public BodyType BodyType { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public Transmission Transmission { get; set; }

        public override string ToString() {
            return string.Format("Entity Car: id={0}, make={1}, model={2}, year={3} ", ID, Make, Model, Year);
         }
    }
}
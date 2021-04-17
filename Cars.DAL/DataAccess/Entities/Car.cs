using System.ComponentModel.DataAnnotations.Schema;

namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Car
    {
        public Car()
        {}

        public Car(string id)
        {
            ID = id;            
        }

        public Car(string id, string make, string model, int year, int doors, string bodyType, string transmission, double price, int odo, Engine engine)
        {
            ID = id;            
            Make = make;
            Model = model;
            Year = year;
            Doors = doors;
            BodyType = (BodyType)System.Enum.Parse(typeof(BodyType),bodyType);
            Transmission = (Transmission)System.Enum.Parse(typeof(Transmission),transmission);
            Price = price;
            Odometer = odo;
            Engine = engine;
        }

        public string ID {get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public double Price { get; set; }
        public int Odometer { get; set; }
        public Engine Engine { get; set; }        

        [Column(TypeName = "nvarchar(128)")]
        public BodyType BodyType { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public Transmission Transmission { get; set; }

        public override string ToString() {
            return string.Format("Entity Car: id={0}, make={1}, model={2}, year={3}, doors={4}, bodytype={5}, transmission={6}, price={7}, odometer={8}, engine={9}", 
            ID, Make, Model, Year, Doors, BodyType, Transmission, Price, Odometer, Engine.ToString());
        }
    }
}
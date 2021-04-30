using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Car
    {
        public Car()
        {}

        public Car(long id)
        {
            ID = id;            
        }

        public Car(long id, Make make, string model, int year, int doors, int seats, BodyType bodyType, double price, int odo, string desc, 
        Engine engine, Transmission transmission, List<Feature> featureList)
        {
            ID = id;            
            Make = make;
            Model = model;
            Year = year;
            Doors = doors;
            Seats = seats;
            Price = price;
            Odometer = odo;
            Description = desc;
            Engine = engine;
            BodyType = bodyType;
            Transmission = transmission;
            FeatureList = featureList;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public Make Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Doors { get; set; }

        public int Seats { get; set; }

        public double Price { get; set; }

        public int Odometer { get; set; }

        public string Description { get; set; } 

        public Engine Engine { get; set; }
     
        [Column(TypeName = "nvarchar(128)")]
        public BodyType BodyType { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public Transmission Transmission { get; set; }

        public List<Feature> FeatureList { get; set; }

        public override string ToString() {
            return $"Entity Car: id={ID}, make={Make}, model={Model}, year={Year}, doors={Doors}, seats={Seats}, body={BodyType}, price={Price}, odometer={Odometer}, " +
            $"desc={Description}, engine={Engine}, transmission={Transmission}, features={string.Join(",", FeatureList)}";
        }
    }
}
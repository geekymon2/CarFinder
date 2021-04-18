using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Car(string id, string make, string model, int year, int doors, string bodyType, string transmission, double price, int odo, 
        int cylinders, int size, int power, string desc)
        {
            ID = id;            
            Make = (Make)System.Enum.Parse(typeof(Make),make);;
            Model = model;
            Year = year;
            Doors = doors;
            BodyType = (BodyType)System.Enum.Parse(typeof(BodyType),bodyType);
            Transmission = (Transmission)System.Enum.Parse(typeof(Transmission),transmission);
            Price = price;
            Odometer = odo;
            Cylinders = cylinders;
            Size = size;
            Power = power;
            Description = desc;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(255)]
        public string ID {get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public Make Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Doors { get; set; }

        public int Seats { get; set; }

        public double Price { get; set; }

        public int Odometer { get; set; }

        public int Cylinders { get; set; }

        public int Size { get; set; }

        public int Power { get; set; }  

        public string Description { get; set; } 
     
        [Column(TypeName = "nvarchar(128)")]
        public BodyType BodyType { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public Transmission Transmission { get; set; }

        public List<Feature> Features { get; set; }

        public override string ToString() {
            return $"Entity Car: id={ID}, make={Make}, model={Model}, year={Year}, doors={Doors}, bodytype={BodyType}, transmission={Transmission}, price={Price}, odometer={Odometer}," +
            $"cylinders={Cylinders}, size={Size}, power={Power}, desc={Description}";
        }
    }
}
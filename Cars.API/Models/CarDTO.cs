namespace Geekymon2.CarsApi.Cars.Api.Models
{
    public class CarDTO
    {
        public CarDTO()
        {}

        public CarDTO(string id)
        {
            ID = id;            
        }

        public string ID {get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string BodyType { get; set; }
        public string Transmission { get; set; }
        public double Price { get; set; }
        public int Odometer { get; set; }
        public int Cylinders { get; set; }
        public int Size { get; set; }
        public int Power { get; set; }  
        public string Description { get; set; } 

        public override string ToString() {
            return $"CarDTO: id={ID}, make={Make}, model={Model}, year={Year}, doors={Doors}, bodytype={BodyType}, transmission={Transmission}, price={Price}, odometer={Odometer}," +
            $"cylinders={Cylinders}, size={Size}, power={Power}, desc={Description}";
        }
    }
}
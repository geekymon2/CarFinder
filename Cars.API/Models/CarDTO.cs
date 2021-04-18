namespace Geekymon2.CarsApi.Cars.API.Models
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
        public int Seats { get; set; }
        public string BodyType { get; set; }
        public double Price { get; set; }
        public int Odometer { get; set; }
        public string Description { get; set; } 
        public EngineDTO EngineDTO { get; set; }
        public TransmissionDTO TransmissionDTO { get; set; }

        public override string ToString() {
            return $"CarDTO: id={ID}, make={Make}, model={Model}, year={Year}, doors={Doors}, bodytype={BodyType}, transmission={TransmissionDTO}, price={Price}, odometer={Odometer}," +
            $"desc={Description}";
        }
    }
}
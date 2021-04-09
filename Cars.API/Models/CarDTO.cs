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

        public override string ToString() {
            return string.Format("CarDTO: id:{0}, make:{1}, model:{2}, year:{3}, price:{4}, odo:{5} ", ID, Make, Model, Year);
         }
    }
}
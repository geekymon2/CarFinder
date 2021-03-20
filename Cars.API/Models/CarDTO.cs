namespace GeekyMon2.CarsApi.Models
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

        public override string ToString() {
            return string.Format("CarDTO: id={0}, make={1}, model={2}, year={3} ", ID, Make, Model, Year);
         }
    }
}
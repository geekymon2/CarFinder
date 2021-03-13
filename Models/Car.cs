namespace GeekyMon2.CarsApi.Models
{
    public class Car
    {
        public string ID {get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public BodyType BodyType { get; set; }
        public Transmission Transmission { get; set; }  
    }
}
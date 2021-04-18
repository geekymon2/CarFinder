namespace Geekymon2.CarsApi.Cars.API.Models
{
    public class TransmissionDTO
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public int Gears { get; set; }

        public TransmissionDTO(string id, string type, string detail, int gears)
        {
            ID = id;
            Type = type;
            Detail = detail;
            Gears = gears;            
        }

        public override string ToString() {
            return $"Entity Transmission: id={ID}, type={Type}, detail={Detail}, gears={Gears}";
        }           
        
    }
}
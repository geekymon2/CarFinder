namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Transmission
    {
        public string ID { get; set; }
        public TransmissionType Type { get; set; }
        public TransmissionTypeDetail Detail { get; set; }
        public int Gears { get; set; }

        public Transmission()
        {}

        public Transmission(string id)
        {
            ID = id;            
        }

        public Transmission(string id, TransmissionType type, TransmissionTypeDetail detail, int gears)
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
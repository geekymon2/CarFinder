namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Transmission
    {
        public TransmissionType Type { get; set; }
        public TransmissionTypeDetail Detail { get; set; }
        public int Gears { get; set; }
    }
}
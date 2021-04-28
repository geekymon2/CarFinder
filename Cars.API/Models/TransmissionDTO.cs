namespace Geekymon2.CarsApi.Cars.API.Models
{
    public class TransmissionDTO
    {
        public string ID { get; set; }
        public TransmissionTypeDTO TransmissionTypeDTO { get; set; }
        public TransmissionTypeDetailDTO TransmissionTypeDetailDTO { get; set; }
        public int Gears { get; set; }

        public TransmissionDTO()
        {}          

        public TransmissionDTO(string id)
        {
            ID = id;            
        }          

        public TransmissionDTO(string id, TransmissionTypeDTO type, TransmissionTypeDetailDTO detail, int gears)
        {
            ID = id;
            TransmissionTypeDTO = type;
            TransmissionTypeDetailDTO = detail;
            Gears = gears;            
        }

        public override string ToString() {
            return $"Entity Transmission: id={ID}, type={TransmissionTypeDTO}, detail={TransmissionTypeDetailDTO}, gears={Gears}";
        }           
        
    }
}
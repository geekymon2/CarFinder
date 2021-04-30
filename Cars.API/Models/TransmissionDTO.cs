namespace Geekymon2.CarsApi.Cars.API.Models
{
    public class TransmissionDTO
    {
        public long ID { get; set; }
        public TransmissionTypeDTO TransmissionTypeDTO { get; set; }
        public TransmissionTypeDetailDTO TransmissionTypeDetailDTO { get; set; }
        public int Gears { get; set; }

        public TransmissionDTO()
        {}          

        public TransmissionDTO(long id)
        {
            ID = id;            
        }          

        public TransmissionDTO(long id, TransmissionTypeDTO type, TransmissionTypeDetailDTO detail, int gears)
        {
            ID = id;
            TransmissionTypeDTO = type;
            TransmissionTypeDetailDTO = detail;
            Gears = gears;            
        }

        public override string ToString() {
            return $"TransmissionDTO: id={ID}, type={TransmissionTypeDTO}, detail={TransmissionTypeDetailDTO}, gears={Gears}";
        }           
        
    }
}
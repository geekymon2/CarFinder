using System.Collections.Generic;

namespace Geekymon2.CarsApi.Cars.API.Models
{
    public class CarDTO
    {
        public CarDTO()
        {}

        public CarDTO(long id)
        {
            ID = id;            
        }

        public long ID {get; set; }
        public MakeDTO MakeDTO { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public BodyTypeDTO BodyTypeDTO { get; set; }
        public double Price { get; set; }
        public int Odometer { get; set; }
        public string Description { get; set; } 
        public EngineDTO EngineDTO { get; set; }
        public TransmissionDTO TransmissionDTO { get; set; }
        public List<FeatureDTO> Features { get; set; }

        public override string ToString() {
            return $"CarDTO: id={ID}, make={MakeDTO}, model={Model}, year={Year}, doors={Doors}, seats={Seats}, bodytype={BodyTypeDTO}, transmission={TransmissionDTO}, price={Price}, odometer={Odometer}," +
            $"desc={Description}, engine={EngineDTO}, transmission={TransmissionDTO}, features={string.Join(",",Features)}";
        }
    }
}
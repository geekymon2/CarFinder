namespace Geekymon2.CarsApi.Cars.API.Models
{
    public class EngineDTO
    {
        public long ID { get; set; }
        public int NoOfCylinders { get; set; }
        public int EngineSizeCC { get; set; }
        public int PowerKW { get; set; }  
        public CylinderConfigurationDTO CylinderConfigDTO { get; set; }
        public DriveTypeDTO DriveTypeDTO { get; set; }
        public FuelTypeDTO FuelTypeDTO { get; set; }
        public double FuelEconomy { get; set; }
        public double PowerToWeight { get; set; }

        public EngineDTO()
        {}          

        public EngineDTO(long id)
        {
            ID = id;            
        }        

        public EngineDTO(long id, int noOfCylinders, int engineSizeCC, int powerKW, CylinderConfigurationDTO config, DriveTypeDTO drive, FuelTypeDTO fuel, double economy, double powerToWeight)
        {
            ID = id;
            NoOfCylinders = noOfCylinders;
            EngineSizeCC = engineSizeCC;
            PowerKW = powerKW;
            CylinderConfigDTO = config;
            DriveTypeDTO = drive;
            FuelTypeDTO = fuel;
            FuelEconomy = economy;
            PowerToWeight = powerToWeight;
        }

        public override string ToString() {
            return $"EngineDTO: id={ID}, cylinders={NoOfCylinders}, size={EngineSizeCC}, power={PowerKW}, config={CylinderConfigDTO}, drive={DriveTypeDTO}, fuel={FuelTypeDTO}, " +
            $"economy={FuelEconomy}, powertoweight={PowerToWeight}";
        }
    }
}
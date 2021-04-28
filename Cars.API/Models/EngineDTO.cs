namespace Geekymon2.CarsApi.Cars.API.Models
{
    public class EngineDTO
    {
        public string ID { get; set; }
        public int NoOfCylinders { get; set; }
        public int EngineSizeCC { get; set; }
        public int PowerKW { get; set; }  
        public string CylinderConfig { get; set; }
        public string DriveType { get; set; }
        public string FuelType { get; set; }
        public double FuelEconomy { get; set; }
        public double PowerToWeight { get; set; }

        public EngineDTO()
        {}          

        public EngineDTO(string id)
        {
            ID = id;            
        }        

        public EngineDTO(string id, int noOfCylinders, int engineSizeCC, int powerKW, string config, string drive, string fuel, double economy, double powerToWeight)
        {
            ID = id;
            NoOfCylinders = noOfCylinders;
            EngineSizeCC = engineSizeCC;
            PowerKW = powerKW;
            CylinderConfig = config;
            DriveType = drive;
            FuelType = fuel;
            FuelEconomy = economy;
            PowerToWeight = powerToWeight;
        }

        public override string ToString() {
            return $"Entity Engine: id={ID}, cylinders={NoOfCylinders}, size={EngineSizeCC}, power={PowerKW}, config={CylinderConfig}, drive={DriveType}, fuel={FuelType}, " +
            $"economy={FuelEconomy}, powertoweight={PowerToWeight}";
        }
    }
}
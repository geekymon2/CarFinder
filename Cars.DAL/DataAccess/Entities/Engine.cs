namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Engine
    {
        public string ID { get; set; }
        public int NoOfCylinders { get; set; }
        public int EngineSizeCC { get; set; }
        public int PowerKW { get; set; }  
        public CylinderConfiguration CylinderConfig { get; set; }
        public DriveType DriveType { get; set; }
        public FuelType FuelType { get; set; }
        public double FuelEconomy { get; set; }
        public double PowerToWeight { get; set; }

        public Engine(string id, int noOfCylinders, int engineSizeCC, int powerKW, CylinderConfiguration config, DriveType drive, FuelType fuel, double economy, double powerToWeight)
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
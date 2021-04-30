using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Engine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public int NoOfCylinders { get; set; }
        public int EngineSizeCC { get; set; }
        public int PowerKW { get; set; }  

        [Column(TypeName = "nvarchar(128)")]
        public CylinderConfiguration CylinderConfig { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public DriveType DriveType { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public FuelType FuelType { get; set; }
        
        public double FuelEconomy { get; set; }
        public double PowerToWeight { get; set; }

        public Engine()
        {}

        public Engine(long id)
        {
            ID = id;            
        }

        public Engine(long id, int noOfCylinders, int engineSizeCC, int powerKW, CylinderConfiguration config, DriveType drive, FuelType fuel, double economy, double powerToWeight)
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
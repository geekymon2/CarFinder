using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;

namespace Geekymon2.CarsApi.Cars.API.Mappers
{
    public class EngineMapper
    {
        public EngineDTO MapToEngineDTO(Engine engine)
        {
            var engineDTO = new EngineDTO();
            engineDTO.ID = engine.ID;
            engineDTO.NoOfCylinders = engine.NoOfCylinders;
            engineDTO.EngineSizeCC = engine.EngineSizeCC;
            engineDTO.PowerKW = engine.PowerKW;
            engineDTO.CylinderConfigDTO = (CylinderConfigurationDTO)engine.CylinderConfig;
            engineDTO.DriveTypeDTO = (DriveTypeDTO)engine.DriveType;
            engineDTO.FuelTypeDTO = (FuelTypeDTO)engine.FuelType;
            engineDTO.FuelEconomy = engine.FuelEconomy;
            engineDTO.PowerToWeight = engine.PowerToWeight;
            return engineDTO;
        }

        public Engine MapToEngineEntity(EngineDTO engineDTO)
        {
            var engine = new Engine();
            engine.ID = engineDTO.ID;
            engine.NoOfCylinders = engineDTO.NoOfCylinders;
            engine.EngineSizeCC = engineDTO.EngineSizeCC;
            engine.PowerKW = engineDTO.PowerKW;
            engine.CylinderConfig = (CylinderConfiguration)engineDTO.CylinderConfigDTO;
            engine.DriveType = (DriveType)engineDTO.DriveTypeDTO;
            engine.FuelType = (FuelType)engineDTO.FuelTypeDTO;
            engine.FuelEconomy = engineDTO.FuelEconomy;
            engine.PowerToWeight = engineDTO.PowerToWeight;
            return engine;
        }        
    }
}
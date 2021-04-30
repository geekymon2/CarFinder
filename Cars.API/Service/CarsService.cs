using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;
using AutoMapper;

namespace Geekymon2.CarsApi.Cars.API.Service
{
    public class CarsService : ICarsService
    {
        private readonly ILogger<CarsService> _logger;  
        private readonly IMapper _mapper;      
        private CarContext _carContext;

        public CarsService(ILogger<CarsService> logger, CarContext carContext, IMapper mapper)
        {
            _carContext = carContext;
            _logger = logger;
            _mapper = mapper;
        }

        public List<CarDTO> GetCars()
        {
            List<CarDTO> cars = new List<CarDTO>();

            foreach (var c in _carContext.Cars)
            {
                cars.Add(_mapper.Map<CarDTO>(c));
                
            }
            
            return cars.ToList();
        }

        public CarDTO AddCar(CarDTO carItem)
        {
            Make make = (Make)System.Enum.Parse(typeof(Make),carItem.MakeDTO.ToString());
            BodyType bodyType = (BodyType)System.Enum.Parse(typeof(BodyType),carItem.BodyTypeDTO.ToString());
            CylinderConfiguration cylinderConfig = (CylinderConfiguration)System.Enum.Parse(typeof(CylinderConfiguration),carItem.EngineDTO.CylinderConfigDTO.ToString());
            DriveType drive = (DriveType)System.Enum.Parse(typeof(DriveType),carItem.EngineDTO.DriveTypeDTO.ToString());
            FuelType fuel = (FuelType)System.Enum.Parse(typeof(FuelType),carItem.EngineDTO.FuelTypeDTO.ToString());
            TransmissionType transmissionType = (TransmissionType)System.Enum.Parse(typeof(TransmissionType),carItem.TransmissionDTO.TransmissionTypeDTO.ToString());
            TransmissionTypeDetail transmissionTypeDetail = (TransmissionTypeDetail)System.Enum.Parse(typeof(TransmissionTypeDetail),carItem.TransmissionDTO.TransmissionTypeDetailDTO.ToString());

            Engine e = new Engine(carItem.EngineDTO.ID, carItem.EngineDTO.NoOfCylinders, carItem.EngineDTO.EngineSizeCC, carItem.EngineDTO.PowerKW, cylinderConfig, 
            drive, fuel, carItem.EngineDTO.FuelEconomy, carItem.EngineDTO.PowerToWeight);

            Transmission t = new Transmission(carItem.TransmissionDTO.ID, transmissionType, transmissionTypeDetail, carItem.TransmissionDTO.Gears);
            List<Feature> features = new List<Feature>();

            //create the new car entity
            var c = new Car(carItem.ID, make, carItem.Model, carItem.Year, carItem.Doors, carItem.Seats, bodyType, carItem.Price, carItem.Odometer, carItem.Description, e, t, features);
            _carContext.Add(c);
            _carContext.SaveChanges();
            _logger.LogInformation(carItem.ToString() + "Total: {0}", _carContext.Cars.Count());

            //populate the dto id after the record is saved.
            carItem.ID = c.ID;
            carItem.EngineDTO.ID = c.Engine.ID;
            carItem.TransmissionDTO.ID = c.Transmission.ID;

            return carItem;
        }

        public CarDTO UpdateCar(long id, CarDTO car)
        {
            var c = _carContext.Cars.FirstOrDefault(
                c => c.ID == id
            );

            if (c != null) {
                c.Make = (Make)System.Enum.Parse(typeof(Make),car.MakeDTO.ToString());
                c.Model = car.Model;
                c.Year = car.Year;
                c.Doors = car.Doors;
                c.Seats = car.Seats;
                c.BodyType = (BodyType)System.Enum.Parse(typeof(BodyType),car.BodyTypeDTO.ToString());

                c.Price = car.Price;
                c.Odometer = car.Odometer;
                c.Description = car.Description;

                c.Engine.NoOfCylinders = car.EngineDTO.NoOfCylinders;
                c.Engine.EngineSizeCC = car.EngineDTO.EngineSizeCC;
                c.Engine.PowerKW = car.EngineDTO.PowerKW;
                c.Engine.CylinderConfig = (CylinderConfiguration)System.Enum.Parse(typeof(CylinderConfiguration),car.EngineDTO.CylinderConfigDTO.ToString());
                c.Engine.DriveType = (DriveType)System.Enum.Parse(typeof(DriveType),car.EngineDTO.DriveTypeDTO.ToString());
                c.Engine.FuelType = (FuelType)System.Enum.Parse(typeof(FuelType),car.EngineDTO.FuelTypeDTO.ToString());
                c.Engine.FuelEconomy = car.EngineDTO.FuelEconomy;
                c.Engine.PowerToWeight = car.EngineDTO.PowerToWeight;

                c.Transmission.Gears = car.TransmissionDTO.Gears;
                c.Transmission.Type = (TransmissionType)System.Enum.Parse(typeof(TransmissionType),car.TransmissionDTO.TransmissionTypeDTO.ToString());
                c.Transmission.Detail = (TransmissionTypeDetail)System.Enum.Parse(typeof(TransmissionTypeDetail),car.TransmissionDTO.TransmissionTypeDetailDTO.ToString());

                _carContext.SaveChanges();
            }

            return car;
        }

        public long DeleteCar(long id)
        {            
            Car c = _carContext.Cars.Find(id);
            if (c != null)
            {
                _carContext.Remove(c);
                _carContext.SaveChanges();
                return id;
            }

            return 0;
        }
        
        ~CarsService()
        {
            _carContext.Dispose();
        }
    }
}
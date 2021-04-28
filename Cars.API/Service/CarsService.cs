using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;

namespace Geekymon2.CarsApi.Cars.API.Service
{
    public class CarsService : ICarsService
    {
        private readonly ILogger<CarsService> _logger;        
        private CarContext _carContext;

        public CarsService(ILogger<CarsService> logger, CarContext carContext)
        {
            _carContext = carContext;
            _logger = logger;
        }

        public List<CarDTO> GetCars()
        {
            var cars = from c in _carContext.Cars
                select new CarDTO()
                {
                    ID = c.ID,
                    MakeDTO = (MakeDTO)System.Enum.Parse(typeof(Make),c.Make.ToString()),
                    Model = c.Model,
                    Year = c.Year,
                    Doors = c.Doors,
                    Odometer = c.Odometer,
                    Price = c.Price,
                    //Transmission = c.Transmission.ToString(),
                    BodyTypeDTO = (BodyTypeDTO)System.Enum.Parse(typeof(BodyType),c.BodyType.ToString()),
                };

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

            var c = new Car(carItem.ID, make, carItem.Model, carItem.Year, carItem.Doors, carItem.Seats, carItem.Price, carItem.Odometer, carItem.Description, e, bodyType, t, features);
            _carContext.Add(c);
            _carContext.SaveChanges();
            _logger.LogInformation(carItem.ToString() + "Total: {0}", _carContext.Cars.Count());

            return carItem;
        }

        public CarDTO UpdateCar(string id, CarDTO car)
        {
            var c = _carContext.Cars.FirstOrDefault(
                c => c.ID == id
            );

            if (c != null) {
                c.Make = (Make)System.Enum.Parse(typeof(Make),car.MakeDTO.ToString());
                c.Model = car.Model;
                c.Year = car.Year;
                c.Doors = car.Doors;
                //c.Transmission = (Transmission)System.Enum.Parse(typeof(Transmission),car.TransmissionDTO.);
                c.BodyType = (BodyType)System.Enum.Parse(typeof(BodyType),car.BodyTypeDTO.ToString());
                c.Price = car.Price;
                c.Odometer = car.Odometer;
                _carContext.SaveChanges();
            }

            return car;
        }

        public string DeleteCar(string id)
        {            
            Car c = _carContext.Cars.Find(id);
            if (c != null)
            {
                _carContext.Remove(c);
                _carContext.SaveChanges();
                return id;
            }

            return null;
        }
        
        ~CarsService()
        {
            _carContext.Dispose();
        }
    }
}
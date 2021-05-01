using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

            foreach (var c in _carContext.Cars.Include(e => e.Engine).Include(t => t.Transmission).Include(f => f.FeatureList))
            {
                cars.Add(_mapper.Map<CarDTO>(c));
                
            }
            
            return cars.ToList();
        }

        public CarDTO AddCar(CarDTO carItem)
        {
            Make make = (Make)System.Enum.Parse(typeof(Make),carItem.Make.ToString());
            BodyType bodyType = (BodyType)System.Enum.Parse(typeof(BodyType),carItem.BodyType.ToString());
            CylinderConfiguration cylinderConfig = (CylinderConfiguration)System.Enum.Parse(typeof(CylinderConfiguration),carItem.Engine.CylinderConfigDTO.ToString());
            DriveType drive = (DriveType)System.Enum.Parse(typeof(DriveType),carItem.Engine.DriveTypeDTO.ToString());
            FuelType fuel = (FuelType)System.Enum.Parse(typeof(FuelType),carItem.Engine.FuelTypeDTO.ToString());
            TransmissionType transmissionType = (TransmissionType)System.Enum.Parse(typeof(TransmissionType),carItem.Transmission.TransmissionTypeDTO.ToString());
            TransmissionTypeDetail transmissionTypeDetail = (TransmissionTypeDetail)System.Enum.Parse(typeof(TransmissionTypeDetail),carItem.Transmission.TransmissionTypeDetailDTO.ToString());

            Engine e = new Engine(carItem.Engine.ID, carItem.Engine.NoOfCylinders, carItem.Engine.EngineSizeCC, carItem.Engine.PowerKW, cylinderConfig, 
            drive, fuel, carItem.Engine.FuelEconomy, carItem.Engine.PowerToWeight);

            Transmission t = new Transmission(carItem.Transmission.ID, transmissionType, transmissionTypeDetail, carItem.Transmission.Gears);
            List<Feature> features = new List<Feature>();

            //create the new car entity
            var c = new Car(carItem.ID, make, carItem.Model, carItem.Year, carItem.Doors, carItem.Seats, bodyType, carItem.Price, carItem.Odometer, carItem.Description, e, t, features);
            _carContext.Add(c);
            _carContext.SaveChanges();
            _logger.LogInformation(carItem.ToString() + "Total: {0}", _carContext.Cars.Count());

            //populate the dto id after the record is saved.
            carItem.ID = c.ID;
            carItem.Engine.ID = c.Engine.ID;
            carItem.Transmission.ID = c.Transmission.ID;

            return carItem;
        }

        public CarDTO UpdateCar(long id, CarDTO car)
        {
            var c = _carContext.Cars.FirstOrDefault(
                c => c.ID == id
            );

            if (c != null) {
                c.Make = (Make)System.Enum.Parse(typeof(Make),car.Make.ToString());
                c.Model = car.Model;
                c.Year = car.Year;
                c.Doors = car.Doors;
                c.Seats = car.Seats;
                c.BodyType = (BodyType)System.Enum.Parse(typeof(BodyType),car.BodyType.ToString());

                c.Price = car.Price;
                c.Odometer = car.Odometer;
                c.Description = car.Description;

                c.Engine.NoOfCylinders = car.Engine.NoOfCylinders;
                c.Engine.EngineSizeCC = car.Engine.EngineSizeCC;
                c.Engine.PowerKW = car.Engine.PowerKW;
                c.Engine.CylinderConfig = (CylinderConfiguration)System.Enum.Parse(typeof(CylinderConfiguration),car.Engine.CylinderConfigDTO.ToString());
                c.Engine.DriveType = (DriveType)System.Enum.Parse(typeof(DriveType),car.Engine.DriveTypeDTO.ToString());
                c.Engine.FuelType = (FuelType)System.Enum.Parse(typeof(FuelType),car.Engine.FuelTypeDTO.ToString());
                c.Engine.FuelEconomy = car.Engine.FuelEconomy;
                c.Engine.PowerToWeight = car.Engine.PowerToWeight;

                c.Transmission.Gears = car.Transmission.Gears;
                c.Transmission.Type = (TransmissionType)System.Enum.Parse(typeof(TransmissionType),car.Transmission.TransmissionTypeDTO.ToString());
                c.Transmission.Detail = (TransmissionTypeDetail)System.Enum.Parse(typeof(TransmissionTypeDetail),car.Transmission.TransmissionTypeDetailDTO.ToString());

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
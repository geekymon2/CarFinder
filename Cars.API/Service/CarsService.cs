using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using Geekymon2.CarsApi.Cars.Api.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;

namespace Geekymon2.CarsApi.Cars.Api.Service
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
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Doors = c.Doors,
                    Transmission = c.Transmission.ToString(),
                    BodyType = c.BodyType.ToString()
                };

            return cars.ToList();
        }

        public CarDTO AddCar(CarDTO carItem)
        {

            var c = new Car(carItem.ID,carItem.Make, carItem.Model, carItem.Year, carItem.Doors, carItem.BodyType, carItem.Transmission);
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
                c.Make = car.Make;
                c.Model = car.Model;
                c.Year = car.Year;
                c.Doors = car.Doors;
                c.Transmission = (Transmission)System.Enum.Parse(typeof(Transmission),car.Transmission);
                c.BodyType = (BodyType)System.Enum.Parse(typeof(BodyType),car.BodyType);
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
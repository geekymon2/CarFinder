using System.Collections.Generic;
using GeekyMon2.CarsApi.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using GeekyMon2.CarsApi.DataAccess.DBContext;
using GeekyMon2.CarsApi.DataAccess.Entities;

namespace GeekyMon2.CarsApi.Service
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
            try 
            {
            _carContext.Add(carItem);
            _carContext.SaveChanges();
            _logger.LogInformation(carItem.ToString() + "Total: {0}", _carContext.Cars.Count());
            }
            catch(System.Exception ex) {
                _logger.LogError("Failed adding car: {0}", ex);
                throw;
            }

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
            Car c = new Car(id);
            _carContext.Remove(c);
            _carContext.SaveChanges();
            return id;
        }
        
        ~CarsService()
        {
            _carContext.Dispose();
        }
    }
}
using System.Collections.Generic;
using GeekyMon2.CarsApi.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

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

        public List<Car> GetCars()
        {
            return _carContext.Cars.ToList();
        }

        public Car AddCar(Car carItem)
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

        public Car UpdateCar(string id, Car car)
        {
            var c = _carContext.Cars.FirstOrDefault(
                c => c.ID == id
            );

            if (c != null) {
                c = car;
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
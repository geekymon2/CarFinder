using System.Collections.Generic;
using GeekyMon2.CarsApi.Models;
using Microsoft.Extensions.Logging;

namespace GeekyMon2.CarsApi.Service
{
    public class CarsService : ICarsService
    {
        private readonly ILogger<CarsService> _logger;        
        private List<Car> _carItems;

        public CarsService(ILogger<CarsService> logger)
        {
            _carItems = new List<Car>();
            _logger = logger;
        }

        public List<Car> GetCars()
        {
            return _carItems;
        }

        public Car AddCar(Car carItem)
        {
            _carItems.Add(carItem);
            _logger.LogInformation(carItem.ToString() + "Total: {0}", _carItems.Count);
            return carItem;
        }

        public Car UpdateCar(string id, Car car)
        {
            for (var index = _carItems.Count - 1; index >= 0; index--)
            {
                if (_carItems[index].ID == id)
                {
                    _carItems[index] = car;
                }
            }
            return car;
        }

        public string DeleteCar(string id)
        {
            for (var index = _carItems.Count - 1; index >= 0; index--)
            {
                if (_carItems[index].ID == id)
                {
                    _carItems.RemoveAt(index);
                }
            }

            return id;
        }
    }
}
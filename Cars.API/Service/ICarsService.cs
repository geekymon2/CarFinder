using System.Collections.Generic;
using Geekymon2.CarsApi.Cars.Api.Models;

namespace Geekymon2.CarsApi.Cars.Api.Service
{
    public interface ICarsService
    {
        public List<CarDTO> GetCars();
        public CarDTO AddCar(CarDTO car);
        public CarDTO UpdateCar(string id, CarDTO car);
        public string DeleteCar(string id);        
    }
}
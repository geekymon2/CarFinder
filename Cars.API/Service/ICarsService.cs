using System.Collections.Generic;
using Geekymon2.CarsApi.Cars.API.Models;

namespace Geekymon2.CarsApi.Cars.API.Service
{
    public interface ICarsService
    {
        public List<CarDTO> GetCars();
        public CarDTO AddCar(CarDTO car);
        public CarDTO UpdateCar(long id, CarDTO car);
        public long DeleteCar(long id);        
    }
}
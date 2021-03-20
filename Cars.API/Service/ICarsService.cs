using System.Collections.Generic;
using GeekyMon2.CarsApi.Models;

namespace GeekyMon2.CarsApi.Service
{
    public interface ICarsService
    {
        public List<CarDTO> GetCars();
        public CarDTO AddCar(CarDTO car);
        public CarDTO UpdateCar(string id, CarDTO car);
        public string DeleteCar(string id);        
    }
}
using System.Collections.Generic;
using GeekyMon2.CarsApi.Models;

namespace GeekyMon2.CarsApi.Service
{
    public interface ICarsService
    {
        public List<Car> GetCars();
        public Car AddCar(Car car);
        public Car UpdateCar(string id, Car car);
        public string DeleteCar(string id);        
    }
}
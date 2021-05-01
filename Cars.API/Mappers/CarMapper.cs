using System.Linq;
using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;

namespace Geekymon2.CarsApi.Cars.API.Mappers
{
    public class CarMapper
    {
        public CarDTO MapToCarDTO(Car car)
        {
            var carDTO = new CarDTO();
            var engineMapper = new EngineMapper();
            var transmissionMapper = new TransmissionMapper();

            carDTO.ID = car.ID;
            carDTO.Make = (MakeDTO)car.Make;
            carDTO.Model = car.Model;
            carDTO.Year = car.Year;
            carDTO.Doors = car.Doors;
            carDTO.Seats = car.Seats;
            carDTO.BodyType = (BodyTypeDTO)car.BodyType;
            carDTO.Price = car.Price;
            carDTO.Odometer = car.Odometer;
            carDTO.Description = car.Description;
            carDTO.Engine = engineMapper.MapToEngineDTO(car.Engine);
            carDTO.Transmission = transmissionMapper.MapToTransmissionDTO(car.Transmission);
            carDTO.Features = car.FeatureList.Select(x => new FeatureDTO() { ID = x.ID, Name = x.Name, Value = x.Value }).ToList();

            return carDTO;
        }

        public Car MapToCarEntity(CarDTO carDTO)
        {
            var car = new Car();
            return car;
        }
        
    }
}
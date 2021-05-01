using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Geekymon2.CarsApi.Cars.API.Mappers;

namespace Geekymon2.CarsApi.Cars.API.Service
{
    public class CarsService : ICarsService
    {
        private readonly ILogger<CarsService> _logger;  
        private readonly CarMapper _mapper;      
        private CarContext _carContext;

        public CarsService(ILogger<CarsService> logger, CarContext carContext, CarMapper mapper)
        {
            _carContext = carContext;
            _logger = logger;
            _mapper = mapper;
        }

        public List<CarDTO> GetCars()
        {
            List<CarDTO> carsList = new List<CarDTO>();

            foreach (var c in _carContext.Cars.Include(e => e.Engine).Include(t => t.Transmission).Include(f => f.FeatureList))
            {
                carsList.Add(_mapper.MapToCarDTO(c));               
            }
            
            return carsList.ToList();
        }

        public CarDTO AddCar(CarDTO carItem)
        {
            var c = _mapper.MapToCarEntity(carItem);

            _carContext.Add(c);
            _carContext.SaveChanges();
            _logger.LogInformation(carItem.ToString() + "Total: {0}", _carContext.Cars.Count());

            //populate the dto id after the record is saved.
            carItem.ID = c.ID;
            carItem.Engine.ID = c.Engine.ID;
            carItem.Transmission.ID = c.Transmission.ID;

            return carItem;
        }

        public CarDTO UpdateCar(long id, CarDTO carItem)
        {
            var c = _carContext.Cars.FirstOrDefault(
                c => c.ID == id
            );

            if (c != null) {
                c = _mapper.MapToCarEntity(carItem);
                _carContext.SaveChanges();
            }

            return carItem;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekyMon2.CarsApi.Models;
using GeekyMon2.CarsApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekyMon2.CarsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private ICarsService _service;

        public CarController(ILogger<CarController> logger, ICarsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/api/cars")]
        public ActionResult<List<Car>> GetCars()
        {
            return _service.GetCars();
        }

        [HttpPost("/api/cars")]
        public ActionResult<Car> AddCar(Car car)
        {
            _service.AddCar(car);
            return car;
        }

        [HttpPut("/api/cars/{id}")]
        public ActionResult<Car> UpdateCar(string id, Car car)
        {
            _service.UpdateCar(id, car);
            return car;
        }   

        [HttpDelete("/api/cars/{id}")]
        public ActionResult<string> DeleteCar(string id)
        {
            _service.DeleteCar(id);
            //_logger.LogInformation("cars", _cars);
            return id;
        }                     
    }
}

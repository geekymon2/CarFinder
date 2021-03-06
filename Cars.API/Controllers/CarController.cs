using System;
using System.Collections.Generic;
using System.Net;
using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Geekymon2.CarsApi.Cars.API.Controllers
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

        [HttpGet("/api/status")]
        public ActionResult<String> GetStatus()
        {
            return $"Car Finder API is Running on {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} Environment. We are testing Github Actions.";
        }

        [HttpGet("/api/cars")]
        public ActionResult<List<CarDTO>> GetCars()
        {
            return _service.GetCars();
        }

        [HttpPost("/api/cars")]
        public ActionResult<CarDTO> AddCar(CarDTO car)
        {
            _service.AddCar(car);
            return car;
        }

        [HttpPut("/api/cars/{id}")]
        public ActionResult<CarDTO> UpdateCar(long id, CarDTO car)
        {
            _service.UpdateCar(id, car);
            return car;
        }   


        [HttpDelete("/api/cars/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> DeleteCar(long id)
        {
            if (_service.DeleteCar(id) == 0)
            {
                _logger.LogError($"Car not found for id: {id}");
		        return NotFound(new ErrorDetails 
                { 
                    StatusCode = Convert.ToInt32(HttpStatusCode.NotFound), 
                    ErrorMessage = $"Car not found for id: {id}." 
                });
            }

            return Ok(id);
        }                     
    }
}

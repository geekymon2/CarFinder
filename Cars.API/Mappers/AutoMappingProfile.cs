using AutoMapper;
using Geekymon2.CarsApi.Cars.API.Models;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;

namespace Geekymon2.CarsApi.Cars.API.Mappers
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Make, MakeDTO>();            
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<Engine, EngineDTO>();
            CreateMap<Transmission, TransmissionDTO>();                        
        }
        
    }
}
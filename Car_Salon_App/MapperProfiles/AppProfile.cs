using AutoMapper;
using Car_Salon_App.Dtos;
using Car_Salon_App.Entities;

namespace Car_Salon_App.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CarDto, Car>().ReverseMap();
        }
    }
}

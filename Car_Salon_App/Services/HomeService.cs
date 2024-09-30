using Core.Dtos;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Car_Salon_App.Services
{
    public class HomeService : IHomeService
	{
		private readonly IMapper mapper;
		private readonly CarSalonDbContext context;
		public HomeService(IMapper mapper, CarSalonDbContext context)
		{
			this.mapper = mapper;
			this.context = context;
		}

		public List<CarDto> GetCars()
		{
			var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).ToList();
			return mapper.Map<List<CarDto>>(cars);
		}
	}
}

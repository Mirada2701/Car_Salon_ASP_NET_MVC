using Core.Dtos;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Data.Entities;

namespace Car_Salon_App.Services
{
	public class CarService : ICarService
	{
		private readonly IMapper mapper;
		private readonly CarSalonDbContext context;

		public CarService(IMapper mapper, CarSalonDbContext context)
		{
			this.mapper = mapper;
			this.context = context;
		}

		public void Create(CarDto car)
		{
			var entity = mapper.Map<Car>(car);

			context.Cars.Add(entity);
			context.SaveChanges();
		}

		public void Delete(int id, IFileService fileService)
		{
			var car = context.Cars.Find(id);

			if (car == null) return; //404

			if(car.ImageUrl != null)
				fileService.DeleteProductImage(car.ImageUrl);
			context.Cars.Remove(car);
			context.SaveChanges();
		}

		public CarDto Edit(int id)
		{
			var car = context.Cars.Find(id);

			return mapper.Map<CarDto>(car);
		}

		public void Edit(CarDto car)
		{
			var entity = mapper.Map<Car>(car);

			context.Cars.Update(entity);
			context.SaveChanges();
		}

		public List<Brand> GetBrands()
		{
			return context.Brands.ToList();
		}

		public List<CarDto> GetCars()
		{
			var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).ToList();
			return mapper.Map<List<CarDto>>(cars);
		}

		public List<Category> GetCategories()
		{
			return context.Categories.ToList();
		}

		public List<Engine> GetEngines()
		{
			return context.Engines.ToList();
		}

		public CarDto GetOne(int id)
		{
			var car = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).FirstOrDefault(c => c.Id == id);

			return mapper.Map<CarDto>(car);
		}
	}
}

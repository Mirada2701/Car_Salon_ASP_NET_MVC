using Core.Dtos;
using Data.Entities;

namespace Core.Interfaces
{
	public interface ICarService
	{
		List<CarDto> GetCars();
		CarDto GetOne(int id);
		void Create(CarDto car);
		CarDto Edit(int id);
		void Edit(CarDto car);
		void Delete(int id);
		List<Category> GetCategories();
		List<Brand> GetBrands();
		List<Engine> GetEngines();

	}
}

using Core.Dtos;
using Data.Entities;

namespace Core.Interfaces
{
	public interface ICartService
	{
        List<CarDto> GetCars();
        List<Car> GetCarsEntity();
		int GetCount();
		void Add(int id);
		void Remove(int id);
		void Clear();
    }
}

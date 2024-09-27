using Core.Dtos;

namespace Core.Interfaces
{
	public interface ICartService
	{
        List<CarDto> GetCars();
		int GetCount();
		void Add(int id);
		void Remove(int id);

    }
}

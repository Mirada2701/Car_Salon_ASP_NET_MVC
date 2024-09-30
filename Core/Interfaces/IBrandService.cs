using Core.Dtos;

namespace Core.Interfaces
{
    public interface IBrandService
    {
        List<BrandDto> GetBrands();
        void Create(BrandDto brand);
    }
}

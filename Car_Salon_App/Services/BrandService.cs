using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Car_Salon_App.Services
{
    public class BrandService : IBrandService
    {
        private readonly IMapper mapper;
        private readonly CarSalonDbContext context;

        public BrandService(IMapper mapper, CarSalonDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public void Create(BrandDto brand)
        {
            var entity = mapper.Map<Brand>(brand);

            context.Brands.Add(entity);
            context.SaveChanges();
        }

        public List<BrandDto> GetBrands()
        {
            var brands = context.Brands.ToList();
            return mapper.Map<List<BrandDto>>(brands);
        }
    }
}

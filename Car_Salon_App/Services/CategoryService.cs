using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Car_Salon_App.Services
{
    public class CategoryService : ICategoryService
    {
		private readonly IMapper mapper;
		private readonly CarSalonDbContext context;

		public CategoryService(IMapper mapper, CarSalonDbContext context)
		{
			this.mapper = mapper;
			this.context = context;
		}
		public void Create(CategoryDto cat)
        {
			var entity = mapper.Map<Category>(cat);

			context.Categories.Add(entity);
			context.SaveChanges();
		}

        public List<CategoryDto> GetCategories()
        {
			var cat = context.Categories.ToList();
			return mapper.Map<List<CategoryDto>>(cat);
		}
    }
}

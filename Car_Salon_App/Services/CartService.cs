using Microsoft.AspNetCore.Http;
using Car_Salon_App.Extensions;
using Core.Dtos;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace Car_Salon_App.Services
{

	public class CartService : ICartService
	{
		private readonly HttpContext httpContext;
        private readonly IMapper mapper;
        private readonly CarSalonDbContext context;

        public CartService(IHttpContextAccessor contextAccessor,IMapper mapper, CarSalonDbContext context)
        {
			httpContext = contextAccessor.HttpContext!;
            this.mapper = mapper;
            this.context = context;
        }
        public List<CarDto> GetCars()
        {
            var ids = httpContext.Session.Get<List<int>>("cart_items") ?? new();

            var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).Where(c => ids.Contains(c.Id)).ToList();

            return mapper.Map<List<CarDto>>(cars);
        }
        public int GetCount()
		{
			var ids = httpContext.Session.Get<List<int>>("cart_items");
			if (ids == null) return 0;

			return ids.Count;
		}

		public void Add(int id)
		{
            var ids = httpContext.Session.Get<List<int>>("cart_items");
            if (ids == null) ids = new();

            ids.Add(id);
            httpContext.Session.Set("cart_items", ids);
        }

        public void Remove(int id)
        {
            var ids = httpContext.Session.Get<List<int>>("cart_items");
            if (ids == null) return; // throw exception

            ids.Remove(id);
            httpContext.Session.Set("cart_items", ids);
        }
    }
}

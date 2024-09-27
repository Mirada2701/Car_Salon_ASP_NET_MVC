using AutoMapper;
using Data;
using Core.Dtos;
using Car_Salon_App.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Salon_App.Controllers
{
    public class CartController : Controller
    {
		private CarSalonDbContext context = new();
		private readonly IMapper mapper;
        public CartController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
			var ids = HttpContext.Session.Get<List<int>>("cart_items") ?? new();

			var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).Where(c => ids.Contains(c.Id)).ToList();

			return View(mapper.Map<List<CarDto>>(cars));
        }
		public IActionResult Add(int id)
		{
			var ids = HttpContext.Session.Get<List<int>>("cart_items");
			if (ids == null) ids = new();

			ids.Add(id);
			HttpContext.Session.Set("cart_items", ids);

			return RedirectToAction("Index");
		}
		public IActionResult Remove(int id)
		{
			var ids = HttpContext.Session.Get<List<int>>("cart_items");
			if (ids == null) return NotFound();

			ids.Remove(id);
			HttpContext.Session.Set("cart_items", ids);

			return RedirectToAction("Index");
		}
	}
}

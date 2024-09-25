using AutoMapper;
using Car_Salon_App.Data;
using Car_Salon_App.Dtos;
using Car_Salon_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Car_Salon_App.Controllers
{
    public class HomeController : Controller
    {
		private CarSalonDbContext context = new();
        private readonly IMapper mapper;
        public HomeController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
			var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).ToList();
			return View(mapper.Map<List<CarDto>>(cars));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

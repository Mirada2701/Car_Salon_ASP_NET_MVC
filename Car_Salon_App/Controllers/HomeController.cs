using Car_Salon_App.Data;
using Car_Salon_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Car_Salon_App.Controllers
{
    public class HomeController : Controller
    {
		private CarSalonDbContext context = new();
		public IActionResult Index()
        {
			var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).ToList();
			return View(cars);
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

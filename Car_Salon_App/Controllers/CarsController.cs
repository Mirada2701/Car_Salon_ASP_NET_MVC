using Car_Salon_App.Data;
using Car_Salon_App.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Salon_App.Controllers
{
    public class CarsController : Controller
    {
        private CarSalonDbContext context = new();

        public CarsController()
        {            
        }
        public IActionResult Index()
        {
            var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).ToList();
            return View(cars);
        }
        public IActionResult Delete(int id)
        {
            var car = context.Cars.Find(id);

            if(car == null) return NotFound(); //404
            
            context.Cars.Remove(car);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Info(int id)
        {
            var car = context.Cars.Include(c => c.Brand).Include(c => c.Category).FirstOrDefault(c => c.Id == id);

            if (car == null)
                return NotFound(); //404            

            return View(car);
        }
    }
}

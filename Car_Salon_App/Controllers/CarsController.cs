using Car_Salon_App.Data;
using Car_Salon_App.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Create()
        {
            SetSelectItems();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                SetSelectItems();
                return View(car);
            }

            context.Cars.Add(car);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var car = context.Cars.Find(id);

            if (car == null) return NotFound();

            SetSelectItems();
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
            {
                SetSelectItems();
                return View(car);
            }

            context.Cars.Update(car);
            context.SaveChanges();

            return RedirectToAction("Index");
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
                return NotFound();           

            return View(car);
        }
        private void SetSelectItems()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(context.Brands.ToList(), "Id", "Name");
        }
    }
}

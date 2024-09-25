using AutoMapper;
using Car_Salon_App.Data;
using Car_Salon_App.Dtos;
using Car_Salon_App.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Car_Salon_App.Controllers
{
    public class CarsController : Controller
    {
        private CarSalonDbContext context = new();
        private readonly IMapper mapper;
        public CarsController(IMapper mapper)
        {   
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var cars = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).ToList();
            return View(mapper.Map<List<CarDto>>(cars));
        }
        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            SetSelectItems();
            return View("Upsert");
        }
        [HttpPost]
        public IActionResult Create(CarDto car)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                SetSelectItems();
                return View("Upsert",car);
            }
            var entity =  mapper.Map<Car>(car);

            context.Cars.Add(entity);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var car = context.Cars.Find(id);

            if (car == null) return NotFound();

            SetSelectItems();
            ViewBag.CreateMode = false;
            return View("Upsert",mapper.Map<CarDto>(car));
        }
        [HttpPost]
        public IActionResult Edit(CarDto car)
        {
            if (!ModelState.IsValid)
            {
                SetSelectItems();
                ViewBag.CreateMode = true;
                return View("Upsert",car);
            }

            var entity = mapper.Map<Car>(car);

            context.Cars.Update(entity);
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
            var car = context.Cars.Include(c => c.Brand).Include(c => c.Category).Include(c => c.Engine).FirstOrDefault(c => c.Id == id);

            if (car == null)
                return NotFound();
            
            return View(car);
        }
        private void SetSelectItems()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(context.Brands.ToList(), "Id", "Name");
            ViewBag.Engines = new SelectList(context.Engines.ToList(), "Id", "Display");
        }
    }
}

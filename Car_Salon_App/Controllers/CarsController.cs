using AutoMapper;
using Data;
using Core.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car_Salon_App.Services;
using Core.Interfaces;

namespace Car_Salon_App.Controllers
{
    public class CarsController : Controller
    {
        public ICarService carService;

		public CarsController(ICarService carService)
        {
			this.carService = carService;
		}
        public IActionResult Index()
        {            
            return View(carService.GetCars());
        }
        public IActionResult Details(int id)
        {
            return View(carService.GetOne(id));
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
				return View("Upsert", car);
			}
			carService.Create(car);

			return RedirectToAction("Index");
		}
        public IActionResult Edit(int id)
        {          
            SetSelectItems();
            ViewBag.CreateMode = false;
            return View("Upsert",carService.Edit(id));
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
           
            carService.Edit(car);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {            
            carService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Info(int id)
        {
			return View(carService.GetOne(id));
		}
        private void SetSelectItems()
        {
            ViewBag.Categories = new SelectList(carService.GetCategories(), "Id", "Name");
            ViewBag.Brands = new SelectList(carService.GetBrands(), "Id", "Name");
            ViewBag.Engines = new SelectList(carService.GetEngines(), "Id", "Display");
        }
    }
}

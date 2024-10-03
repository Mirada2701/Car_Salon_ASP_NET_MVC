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
		private readonly IFileService fileService;

		public CarsController(ICarService carService,IFileService fileService)
        {
			this.carService = carService;
			this.fileService = fileService;
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
        public async Task<IActionResult> Create(CarDto car)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.CreateMode = true;
				SetSelectItems();
				return View("Upsert", car);
			}
            if (car.Image != null)
                car.ImageUrl = await fileService.SaveProductImage(car.Image);

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
        public async Task<IActionResult> Edit(CarDto car)
        {
            if (!ModelState.IsValid)
            {
                SetSelectItems();
                ViewBag.CreateMode = true;
                return View("Upsert",car);
            }
            if (car.Image != null)
                car.ImageUrl = await fileService.EditProductImage(car.ImageUrl, car.Image);

            carService.Edit(car);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {         
            carService.Delete(id,fileService);
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

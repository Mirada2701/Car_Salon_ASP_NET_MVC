using Car_Salon_App.Services;
using Core.Dtos;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Car_Salon_App.Controllers
{
    public class EnginesController : Controller
    {
        private readonly IEngineService engineService;

        public EnginesController(IEngineService engineService)
        {
            this.engineService = engineService;
        }
        public IActionResult Index()
        {
            return View(engineService.GetEngines());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EngineDto eng)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", eng);
            }
            engineService.Create(eng);
            return RedirectToAction("Index");
        }
    }
}

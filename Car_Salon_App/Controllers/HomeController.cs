using AutoMapper;
using Data;
using Core.Dtos;
using Car_Salon_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Core.Interfaces;

namespace Car_Salon_App.Controllers
{
    public class HomeController : Controller
    {
        public IHomeService homeService;

		public HomeController(IHomeService homeService)
        {
			this.homeService = homeService;
		}
        public IActionResult Index()
        {
			return View(homeService.GetCars());
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

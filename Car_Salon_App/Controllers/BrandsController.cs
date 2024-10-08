﻿using Car_Salon_App.Extensions;
using Car_Salon_App.Services;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car_Salon_App.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        public IActionResult Index()
        {
            return View(brandService.GetBrands());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandDto cat)
        {
            brandService.Create(cat);
            return RedirectToAction("Index");
        }
    }
}

using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Car_Salon_App.Controllers
{
    public class CategoriesController : Controller
    {
		private readonly ICategoryService categoryService;

		public CategoriesController(ICategoryService categoryService)
        {
			this.categoryService = categoryService;
		}
        public IActionResult Index()
        {
            return View(categoryService.GetCategories());
        }
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(CategoryDto cat)
		{
			categoryService.Create(cat);
			return RedirectToAction("Index");
		}
	}
}

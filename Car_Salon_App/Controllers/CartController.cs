using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace Car_Salon_App.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController( ICartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index()
        {		
			return View(cartService.GetCars());
        }
		public IActionResult Add(int id,string? returnUrl)
		{
			cartService.Add(id);
			return Redirect(returnUrl ?? "/");
		}
		public IActionResult Remove(int id)
		{		
			cartService.Remove(id);
			return RedirectToAction("Index");
		}
	}
}
